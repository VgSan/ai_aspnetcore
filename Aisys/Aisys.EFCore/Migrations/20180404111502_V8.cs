using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aisys.EFCore.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientNo",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "EmployeeNo",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "ClientNo",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "OrderProcess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "OrderProcess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProcess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcess_ClientId",
                table: "OrderProcess",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcess_EmployeeId",
                table: "OrderProcess",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcess_OrderId",
                table: "OrderProcess",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProcess_Client_ClientId",
                table: "OrderProcess",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProcess_Employee_EmployeeId",
                table: "OrderProcess",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProcess_Order_OrderId",
                table: "OrderProcess",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProcess_Client_ClientId",
                table: "OrderProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProcess_Employee_EmployeeId",
                table: "OrderProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProcess_Order_OrderId",
                table: "OrderProcess");

            migrationBuilder.DropIndex(
                name: "IX_OrderProcess_ClientId",
                table: "OrderProcess");

            migrationBuilder.DropIndex(
                name: "IX_OrderProcess_EmployeeId",
                table: "OrderProcess");

            migrationBuilder.DropIndex(
                name: "IX_OrderProcess_OrderId",
                table: "OrderProcess");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Order_ClientId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProcess");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "ClientNo",
                table: "OrderProcess",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNo",
                table: "OrderProcess",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "OrderProcess",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientNo",
                table: "Order",
                nullable: true);
        }
    }
}
