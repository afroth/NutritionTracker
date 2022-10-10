using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionTrackerServer.Migrations
{
    public partial class intialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ingredientName = table.Column<string>(maxLength: 50, nullable: false),
                    calories = table.Column<int>(nullable: false),
                    fats = table.Column<int>(nullable: false),
                    protein = table.Column<int>(nullable: false),
                    sugar = table.Column<int>(nullable: false),
                    carbs = table.Column<int>(nullable: false)
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
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "calories", "carbs", "fats", "ingredientName", "protein", "sugar" },
                values: new object[] { 1, 90, 0, 10, "Eggs", 20, 0 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "calories", "carbs", "fats", "ingredientName", "protein", "sugar" },
                values: new object[] { 2, 60, 0, 0, "Tuna Fish", 36, 0 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "calories", "carbs", "fats", "ingredientName", "protein", "sugar" },
                values: new object[] { 3, 120, 45, 5, "Oat Meal", 8, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "password", "username" });
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
