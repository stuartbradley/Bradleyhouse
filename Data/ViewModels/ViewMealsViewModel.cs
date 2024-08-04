using BradleyHouse.Data.Models.MealPrep;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static MudBlazor.Colors;

//make this work like a real viewmodel. Expose Values
namespace Weekly_Shopping.Data.ViewModels
{
    public class ViewMealsViewModel
    {
        private readonly MealPlannerContext _mealPlannerContext;
        private List<MealModel> _meals { get; set; }
        public int Servings { get; set; } = 2;
        public List<MealModel> FilteredList { get; set; } 

        public ViewMealsViewModel(MealPlannerContext mealPlannerContext)
        {
            var meals = mealPlannerContext.Meals.Include(x => x.Ingredients).ThenInclude(x => x.Food)
                .ToList();
            _meals = new List<MealModel>();
            meals.ForEach(x => _meals.Add(new MealModel(x, Save)));
            _mealPlannerContext = mealPlannerContext;
            FilteredList = new List<MealModel>(_meals);
        }

        public async Task Save()
        {
            await _mealPlannerContext.SaveChangesAsync();
        }

        public async Task deleteMeal(int id)
        {
            _mealPlannerContext.Remove(_mealPlannerContext.Find<Meal>(id));
            await _mealPlannerContext.SaveChangesAsync();
            FilteredList.RemoveAll(x => x.Id == id);
        }


        public void searchChanged(string value)
        {
            FilteredList.Clear();
            FilteredList = _meals.Where(x => x.Name.ToLower().Contains(value.ToLower())).ToList();
            FilteredList.AddRange(_meals.Where(x => x.Ingredients.Any(x => x.Food.Name.ToLower().Contains(value.ToLower()))));
            FilteredList = FilteredList.Distinct().OrderBy(x => x.Name).ToList();
        }

        public void ViewMeal(MealModel meal)
        {
            meal.SetIngredients(_mealPlannerContext.Meals.Include(x => x.Ingredients).Where(x => x.Id == meal.Id).SelectMany(x => x.Ingredients).ToList());
            meal.ViewMeal = !meal.ViewMeal;
        }

        public void CalculateServings()
        {

        }

        public void CreateShoppingList()
        {

            Dictionary<int, ShoppingListIngredient> ingredients = new();

            foreach (var ingredient in _meals.Where(x => x.Selected).SelectMany(x => x.Ingredients))
            {
                if (ingredients.ContainsKey(ingredient.FoodId))
                {
                    ingredients[ingredient.FoodId].Amount += ingredient.Amount;
                }
                else
                {
                    ingredients[ingredient.FoodId] = new ShoppingListIngredient()
                    {
                        Amount = ingredient.Amount,
                        FoodId = ingredient.FoodId,
                        Measurement = ingredient.Measurement,
                        Picked = false,
                    };
                }


            }

            ShoppingList shoppingList = new ShoppingList()
            {
                Name = DateTime.Now.ToString(),
                DateCreated = DateTime.Now,
                Meals = _meals.Select(x => new ShoppingListMeal()
                {
                    MealId = x.Id,
                }).ToList(),
                Ingredients = ingredients.Values.ToList()
            };

            _mealPlannerContext.Add(shoppingList);
            _mealPlannerContext.SaveChanges();

            _meals.ForEach(x => x.Selected = false);
        }
    }

}

public class MealModel
{
    private Meal _meal;
    private readonly Func<Task> _save;

    public MealModel(Meal meal, Func<Task> save)
    {
        _meal = meal;
        _save = save;
    }
    public bool ViewMeal { get; set; } = false;

    public int Id => _meal.Id;
    public string Name => _meal.Name;
    public IReadOnlyList<Ingredient> Ingredients => _meal.Ingredients;
    public int StockCount => _meal.StockCount;
    public int NumberOfServings => _meal.NumberOfServings;

    public bool Selected { get; set; }
    public async Task addOneToStock()
    {
        _meal.StockCount++;
        await _save.Invoke();
    }

    public async Task removeOneFromStock()
    {
        _meal.StockCount -= 1; 
        await _save.Invoke();
    }

    public void SetIngredients(List<Ingredient> ingredients)
    {
        _meal.Ingredients = ingredients;
    }
}
