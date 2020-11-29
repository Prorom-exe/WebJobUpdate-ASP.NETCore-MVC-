using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJob.Migrations
{
    public partial class shopcart22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyTovar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyTovar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyTovar_ShopCart_ShopId",
                        column: x => x.ShopId,
                        principalTable: "ShopCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyTovar_ShopId",
                table: "BuyTovar",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyTovar");
        }
    }
}
