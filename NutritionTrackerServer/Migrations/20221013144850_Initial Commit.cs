using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionTrackerServer.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(maxLength: 50, nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    Fats = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    Sugar = table.Column<int>(nullable: false),
                    Carbs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Calories", "Carbs", "Fats", "IngredientName", "Protein", "Sugar" },
                values: new object[] { 1, 90, 0, 10, "Eggs", 20, 0 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Calories", "Carbs", "Fats", "IngredientName", "Protein", "Sugar" },
                values: new object[] { 2, 60, 0, 0, "Tuna Fish", 36, 0 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Calories", "Carbs", "Fats", "IngredientName", "Protein", "Sugar" },
                values: new object[] { 3, 120, 45, 5, "Oat Meal", 8, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
