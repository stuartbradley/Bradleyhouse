using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class many2many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_ShoppingList_ShoppingListId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_ShoppingListId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "MealShoppingList",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealShoppingList", x => new { x.MealsId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_MealShoppingList_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealShoppingList_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealShoppingList_ShoppingListId",
                table: "MealShoppingList",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealShoppingList");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ShoppingListId",
                table: "Meals",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_ShoppingList_ShoppingListId",
                table: "Meals",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");
        }
    }
}
