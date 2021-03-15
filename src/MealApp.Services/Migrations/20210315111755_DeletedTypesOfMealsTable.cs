using Microsoft.EntityFrameworkCore.Migrations;

namespace MealApp.Services.Migrations
{
    public partial class DeletedTypesOfMealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_TypeOfMeals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "TypeOfMeals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_TypeOfMealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TypeOfMealId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfMeal",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfMeal",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfMealId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeOfMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfMeals", x => x.Id);
                });

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
                onDelete: ReferentialAction.SetNull);
        }
    }
}
