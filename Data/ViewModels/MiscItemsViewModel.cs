using BradleyHouse.Data.Models.MealPrep;
using Weekly_Shopping.Data;

namespace BradleyHouse.Data.ViewModels
{
    public class MiscItemsViewModel
    {
        private readonly MealPlannerContext _context;
        private List<MiscItem> _miscItems = new List<MiscItem>();

        public MiscItemsViewModel(MealPlannerContext context)
        {
            _context = context;
            _context.MiscItems.ToList();
        }



    }
}
