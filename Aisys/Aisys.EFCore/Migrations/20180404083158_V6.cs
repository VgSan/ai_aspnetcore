using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aisys.EFCore.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantWorkflow");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.CreateTable(
                name: "EmployeeWorkflow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkflow_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkflow_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroup_ProductTemplate_ProductTemplateId",
                        column: x => x.ProductTemplateId,
                        principalTable: "ProductTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkflow_EmployeeId",
                table: "EmployeeWorkflow",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkflow_WorkflowId",
                table: "EmployeeWorkflow",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                table: "Product",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductTemplateId",
                table: "ProductGroup",
                column: "ProductTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkflow");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "ProductTemplate");

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MailAddress = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantWorkflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    WorkflowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantWorkflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantWorkflow_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantWorkflow_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyWebsite = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Projects = table.Column<string>(nullable: true),
                    Technologies = table.Column<string>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantWorkflow_ApplicantId",
                table: "ApplicantWorkflow",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantWorkflow_WorkflowId",
                table: "ApplicantWorkflow",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ApplicantId",
                table: "Experience",
                column: "ApplicantId");
        }
    }
}
