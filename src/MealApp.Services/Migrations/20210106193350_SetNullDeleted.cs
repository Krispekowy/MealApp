using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class SetNullDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfMealId",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals",
                column: "TypeOfMealId",
                principalTable: "TypeOfMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfMealId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals",
                column: "TypeOfMealId",
                principalTable: "TypeOfMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
