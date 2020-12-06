using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class _12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyTovar_ShopCart_ShopId",
                table: "BuyTovar");

            migrationBuilder.DropIndex(
                name: "IX_BuyTovar_ShopId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "TovarName",
                table: "BuyTovar");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "BuyTovar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BuyTovar");

            migrationBuilder.AddColumn<string>(
                name: "CatalogId",
                table: "BuyTovar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BuyTovar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "BuyTovar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TovarName",
                table: "BuyTovar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyTovar_ShopId",
                table: "BuyTovar",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyTovar_ShopCart_ShopId",
                table: "BuyTovar",
                column: "ShopId",
                principalTable: "ShopCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
