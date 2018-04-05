using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aisys.EFCore.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProcess_Client_ClientId",
                table: "OrderProcess");

            migrationBuilder.DropIndex(
                name: "IX_OrderProcess_ClientId",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderProcess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "OrderProcess",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcess_ClientId",
                table: "OrderProcess",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProcess_Client_ClientId",
                table: "OrderProcess",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
