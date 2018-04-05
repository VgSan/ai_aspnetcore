using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Aisys.EntityFrameworkCore;
using AutoMapper;
using Aisys.Application;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Aisys.Web.Host.Authentication.JwtBearer;
using Aisys.Web.Host.ExtensionMethods;

namespace Aisys.Web.Host
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _signingKey =
                 new SymmetricSecurityKey(
                     Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            _tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                // Validate the token expiry
                ValidateLifetime = true,
                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
            
            _tokenProviderOptions = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddDbContext<AisysDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddMvc();

            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
                                          //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
            //corsBuilder.WithOrigins("http://localhost:8775");
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Aisys API", Version = "v1" });
            });

            ConfigureAuth(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aisys API V1");
            });

            // ********************
            // USE CORS - might not be required.
            // ********************
            app.UseCors("SiteCorsPolicy");

            app.UseTokenProvider(_tokenProviderOptions);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
