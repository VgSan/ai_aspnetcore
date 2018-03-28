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

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<Applicant> Applicant { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }

        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<ApplicantWorkflow> ApplicantWorkflow { get; set; }

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
