namespace Weekly_Shopping.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Ingredient> Ingredients { get; set; } = new();
        public int StockCount { get; set; }
        public int NumberOfServings { get; set; } = 2;
    }
}
