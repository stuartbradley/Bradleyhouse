using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class shoppingListRebuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredient_Ingredients_IngredientId",
                table: "ShoppingListIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredient_ShoppingListMeal_ShoppingListMealId",
                table: "ShoppingListIngredient");

            migrationBuilder.DropTable(
                name: "ShoppingListShoppingListMeal");

            migrationBuilder.RenameColumn(
                name: "ShoppingListMealId",
                table: "ShoppingListIngredient",
                newName: "ShoppingListId");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "ShoppingListIngredient",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_ShoppingListMealId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_IngredientId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_FoodId");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "ShoppingListMeal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ShoppingListIngredient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "ShoppingListIngredient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListMeal_ShoppingListId",
                table: "ShoppingListMeal",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredient_Foods_FoodId",
                table: "ShoppingListIngredient",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredient_ShoppingList_ShoppingListId",
                table: "ShoppingListIngredient",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListMeal_ShoppingList_ShoppingListId",
                table: "ShoppingListMeal",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredient_Foods_FoodId",
                table: "ShoppingListIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredient_ShoppingList_ShoppingListId",
                table: "ShoppingListIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListMeal_ShoppingList_ShoppingListId",
                table: "ShoppingListMeal");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListMeal_ShoppingListId",
                table: "ShoppingListMeal");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "ShoppingListMeal");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ShoppingListIngredient");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "ShoppingListIngredient");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingListIngredient",
                newName: "ShoppingListMealId");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "ShoppingListIngredient",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_ShoppingListId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_ShoppingListMealId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_FoodId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_IngredientId");

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
                name: "IX_ShoppingListShoppingListMeal_ShoppingListId",
                table: "ShoppingListShoppingListMeal",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredient_Ingredients_IngredientId",
                table: "ShoppingListIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredient_ShoppingListMeal_ShoppingListMealId",
                table: "ShoppingListIngredient",
                column: "ShoppingListMealId",
                principalTable: "ShoppingListMeal",
                principalColumn: "Id");
        }
    }
}
