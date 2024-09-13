using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class addedshoppingListForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListMeal",
                table: "ShoppingListMeal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListIngredient",
                table: "ShoppingListIngredient");

            migrationBuilder.RenameTable(
                name: "ShoppingListMeal",
                newName: "ShoppingListMeals");

            migrationBuilder.RenameTable(
                name: "ShoppingListIngredient",
                newName: "ShoppingListIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListMeal_ShoppingListId",
                table: "ShoppingListMeals",
                newName: "IX_ShoppingListMeals_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_ShoppingListId",
                table: "ShoppingListIngredients",
                newName: "IX_ShoppingListIngredients_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredient_FoodId",
                table: "ShoppingListIngredients",
                newName: "IX_ShoppingListIngredients_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListIngredients",
                table: "ShoppingListIngredients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MiscItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscItems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredients_Foods_FoodId",
                table: "ShoppingListIngredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredients_ShoppingList_ShoppingListId",
                table: "ShoppingListIngredients",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListMeals_ShoppingList_ShoppingListId",
                table: "ShoppingListMeals",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredients_Foods_FoodId",
                table: "ShoppingListIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredients_ShoppingList_ShoppingListId",
                table: "ShoppingListIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListMeals_ShoppingList_ShoppingListId",
                table: "ShoppingListMeals");

            migrationBuilder.DropTable(
                name: "MiscItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListIngredients",
                table: "ShoppingListIngredients");

            migrationBuilder.RenameTable(
                name: "ShoppingListMeals",
                newName: "ShoppingListMeal");

            migrationBuilder.RenameTable(
                name: "ShoppingListIngredients",
                newName: "ShoppingListIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListMeals_ShoppingListId",
                table: "ShoppingListMeal",
                newName: "IX_ShoppingListMeal_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListIngredients_FoodId",
                table: "ShoppingListIngredient",
                newName: "IX_ShoppingListIngredient_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListMeal",
                table: "ShoppingListMeal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListIngredient",
                table: "ShoppingListIngredient",
                column: "Id");

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
    }
}
