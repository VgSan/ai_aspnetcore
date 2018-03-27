using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aisys.EFCore.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_UserRole_UserRoleId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserRoleId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRole");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Role",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserRoleId",
                table: "Role",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_UserRole_UserRoleId",
                table: "Role",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
