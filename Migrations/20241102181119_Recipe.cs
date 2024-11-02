using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class Recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeUrl",
                table: "Meals");
        }
    }
}
