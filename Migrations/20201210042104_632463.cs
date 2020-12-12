using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class _632463 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyTovar_AspNetUsers_UserId",
                table: "BuyTovar");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCart_AspNetUsers_UserId",
                table: "ShopCart");

            migrationBuilder.DropIndex(
                name: "IX_ShopCart_UserId",
                table: "ShopCart");

            migrationBuilder.DropIndex(
                name: "IX_BuyTovar_UserId",
                table: "BuyTovar");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShopCart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BuyTovar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShopCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BuyTovar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCart_UserId",
                table: "ShopCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyTovar_UserId",
                table: "BuyTovar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyTovar_AspNetUsers_UserId",
                table: "BuyTovar",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCart_AspNetUsers_UserId",
                table: "ShopCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
