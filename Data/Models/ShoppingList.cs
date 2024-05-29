namespace Weekly_Shopping.Data.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }    
        public List<Meal> Meals { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Today;
    }
}
