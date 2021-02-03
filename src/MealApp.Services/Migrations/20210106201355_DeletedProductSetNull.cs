using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class DeletedProductSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealProducts_Products_ProductId",
                table: "MealProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_MealProducts_Products_ProductId",
                table: "MealProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealProducts_Products_ProductId",
                table: "MealProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_MealProducts_Products_ProductId",
                table: "MealProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
