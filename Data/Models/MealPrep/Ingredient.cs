namespace BradleyHouse.Data.Models.MealPrep
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; } = new();
        public decimal Amount { get; set; }
        public string? Measurement { get; set; } = "";

        public override string ToString()
        {
            if (Amount == 1 && Measurement == "")
                return $"{Food.Name}";
            else
                return $"{Food.Name} - {Amount.ToString("0.#")}{Measurement}";
        }
    }
}
