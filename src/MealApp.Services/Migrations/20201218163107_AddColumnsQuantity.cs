using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class AddColumnsQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KcalInUnit",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Kcal",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityUnit",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MealProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MealProducts");

            migrationBuilder.AddColumn<decimal>(
                name: "KcalInUnit",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
