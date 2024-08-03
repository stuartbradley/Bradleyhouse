using Weekly_Shopping.Migrations;

namespace BradleyHouse.Data.Models.MealPrep
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShoppingListMeal> Meals { get; set; }
        public List<ShoppingListIngredient> Ingredients { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Today;
    }
}
