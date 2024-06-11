namespace BradleyHouse.Data.Models.MealPrep
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public List<Meal> Meals { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Today;
    }
}
