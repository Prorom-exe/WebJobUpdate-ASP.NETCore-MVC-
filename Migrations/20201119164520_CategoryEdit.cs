using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class CategoryEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Path",
                table: "Tovar",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Tovar");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Category");
        }
    }
}
