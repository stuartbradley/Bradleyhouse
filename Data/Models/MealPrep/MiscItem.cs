namespace BradleyHouse.Data.Models.MealPrep
{
    public class MiscItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateEntered { get; set; } = DateTime.Now;
    }
}
