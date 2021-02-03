using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class ChangeNameForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayDietMeals_DayDiets_DayDietId",
                table: "DayDietMeals");

            migrationBuilder.RenameColumn(
                name: "DayDietId",
                table: "DayDietMeals",
                newName: "DietDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayDietMeals_DayDiets_DietDayId",
                table: "DayDietMeals",
                column: "DietDayId",
                principalTable: "DayDiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayDietMeals_DayDiets_DietDayId",
                table: "DayDietMeals");

            migrationBuilder.RenameColumn(
                name: "DietDayId",
                table: "DayDietMeals",
                newName: "DayDietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayDietMeals_DayDiets_DayDietId",
                table: "DayDietMeals",
                column: "DayDietId",
                principalTable: "DayDiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
