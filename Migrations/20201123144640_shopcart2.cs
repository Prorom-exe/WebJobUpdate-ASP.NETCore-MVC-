using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class shopcart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChopCart_AspNetUsers_UserId",
                table: "ChopCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ChopCart_Tovar_TovarId",
                table: "ChopCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChopCart",
                table: "ChopCart");

            migrationBuilder.RenameTable(
                name: "ChopCart",
                newName: "ShopCart");

            migrationBuilder.RenameIndex(
                name: "IX_ChopCart_UserId",
                table: "ShopCart",
                newName: "IX_ShopCart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChopCart_TovarId",
                table: "ShopCart",
                newName: "IX_ShopCart_TovarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCart",
                table: "ShopCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCart_AspNetUsers_UserId",
                table: "ShopCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCart_Tovar_TovarId",
                table: "ShopCart",
                column: "TovarId",
                principalTable: "Tovar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCart_AspNetUsers_UserId",
                table: "ShopCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCart_Tovar_TovarId",
                table: "ShopCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCart",
                table: "ShopCart");

            migrationBuilder.RenameTable(
                name: "ShopCart",
                newName: "ChopCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCart_UserId",
                table: "ChopCart",
                newName: "IX_ChopCart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCart_TovarId",
                table: "ChopCart",
                newName: "IX_ChopCart_TovarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChopCart",
                table: "ChopCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChopCart_AspNetUsers_UserId",
                table: "ChopCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChopCart_Tovar_TovarId",
                table: "ChopCart",
                column: "TovarId",
                principalTable: "Tovar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
