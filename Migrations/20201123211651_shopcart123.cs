using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class shopcart123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCart_Tovar_TovarId",
                table: "ShopCart");

            migrationBuilder.DropIndex(
                name: "IX_ShopCart_TovarId",
                table: "ShopCart");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "ShopCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogId",
                table: "ShopCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShopCart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TovarName",
                table: "ShopCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyQantity",
                table: "BuyTovar",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "TovarId",
                table: "BuyTovar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TovarName",
                table: "BuyTovar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BuyTovar",
                type: "nvarchar(450)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyTovar_AspNetUsers_UserId",
                table: "BuyTovar");

            migrationBuilder.DropIndex(
                name: "IX_BuyTovar_UserId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "ShopCart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShopCart");

            migrationBuilder.DropColumn(
                name: "TovarName",
                table: "ShopCart");

            migrationBuilder.DropColumn(
                name: "BuyQantity",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "TovarId",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "TovarName",
                table: "BuyTovar");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BuyTovar");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "ShopCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCart_TovarId",
                table: "ShopCart",
                column: "TovarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCart_Tovar_TovarId",
                table: "ShopCart",
                column: "TovarId",
                principalTable: "Tovar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
