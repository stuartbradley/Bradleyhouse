using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class shoppingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_ShoppingList_ShoppingListId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_Meals_ShoppingListId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Meals");
        }
    }
}
