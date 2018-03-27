﻿// <auto-generated />
using Aisys.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Aisys.EFCore.Migrations
{
    [DbContext(typeof(AisysDbContext))]
    [Migration("20180327160423_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aisys.Core.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("MailAddress");

                    b.Property<string>("MobileNo");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("PhoneNo");

                    b.HasKey("Id");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("Aisys.Core.ApplicantWorkflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionTime");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("ApplicantId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("WorkflowId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("ApplicantWorkflow");
                });

            modelBuilder.Entity("Aisys.Core.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("ApplicantId");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyWebsite");

                    b.Property<string>("Designation");

                    b.Property<DateTime>("FromDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Projects");

                    b.Property<string>("Technologies");

                    b.Property<DateTime>("ToDate");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Aisys.Core.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("RoleCd");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Aisys.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Aisys.Core.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int?>("RoleId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Aisys.Core.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime>("ExpiryDateTime");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Token");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Aisys.Core.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProcessName");

                    b.Property<int>("ProcessOrder");

                    b.HasKey("Id");

                    b.ToTable("Workflow");
                });

            modelBuilder.Entity("Aisys.Core.ApplicantWorkflow", b =>
                {
                    b.HasOne("Aisys.Core.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aisys.Core.Workflow", "Workflow")
                        .WithMany()
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aisys.Core.Experience", b =>
                {
                    b.HasOne("Aisys.Core.Applicant")
                        .WithMany("Experiences")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aisys.Core.UserRole", b =>
                {
                    b.HasOne("Aisys.Core.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Aisys.Core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Aisys.Core.UserToken", b =>
                {
                    b.HasOne("Aisys.Core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
