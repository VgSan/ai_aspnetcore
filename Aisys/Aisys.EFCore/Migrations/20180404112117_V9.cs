using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aisys.EFCore.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ProductGroup_ProductGroupId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ProductGroupId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ServiceGroupId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionCode",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionType",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceGroupId",
                table: "Service",
                column: "ServiceGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceGroup_ServiceGroupId",
                table: "Service",
                column: "ServiceGroupId",
                principalTable: "ServiceGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceGroup_ServiceGroupId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceGroupId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceGroupId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ActionCode",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "Service",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProductGroupId",
                table: "Service",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ProductGroup_ProductGroupId",
                table: "Service",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
