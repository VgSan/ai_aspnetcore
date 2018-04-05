using Microsoft.EntityFrameworkCore;
using Aisys.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aisys.EntityFrameworkCore
{
    public class AisysDbContext : DbContext
    {
        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }

        public virtual DbSet<Client> Client { get; set; }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderProcess> OrderProcess { get; set; }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceGroup> ServiceGroup { get; set; }
        public virtual DbSet<Template> Template { get; set; }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public virtual DbSet<Employee> Employee { get; set; } 

        public AisysDbContext(DbContextOptions<AisysDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
