using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class shoppingListIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealShoppingList");

            migrationBuilder.CreateTable(
                name: "ShoppingListMeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListMeal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Picked = table.Column<bool>(type: "bit", nullable: false),
                    ShoppingListMealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredient_ShoppingListMeal_ShoppingListMealId",
                        column: x => x.ShoppingListMealId,
                        principalTable: "ShoppingListMeal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListShoppingListMeal",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListShoppingListMeal", x => new { x.MealsId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_ShoppingListShoppingListMeal_ShoppingListMeal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "ShoppingListMeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListShoppingListMeal_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredient_IngredientId",
                table: "ShoppingListIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredient_ShoppingListMealId",
                table: "ShoppingListIngredient",
                column: "ShoppingListMealId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListShoppingListMeal_ShoppingListId",
                table: "ShoppingListShoppingListMeal",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListIngredient");

            migrationBuilder.DropTable(
                name: "ShoppingListShoppingListMeal");

            migrationBuilder.DropTable(
                name: "ShoppingListMeal");

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
    }
}
