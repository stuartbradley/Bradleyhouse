using BradleyHouse.Data.Models.MealPrep;

namespace BradleyHouse.Data.ViewModels
{
    public class ShoppingListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ShoppingListMealViewModel> Meals { get; set; } = new List<ShoppingListMealViewModel>();
    }

    public class ShoppingListMealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

}
