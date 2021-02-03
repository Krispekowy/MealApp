using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_TypeId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfMealId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TypeOfMealId",
                table: "Meals",
                column: "TypeOfMealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals",
                column: "TypeOfMealId",
                principalTable: "TypeOfMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TypeOfMealId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TypeId",
                table: "Meals",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeId",
                table: "Meals",
                column: "TypeId",
                principalTable: "TypeOfMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
