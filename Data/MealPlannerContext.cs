using Microsoft.EntityFrameworkCore;
using Weekly_Shopping.Data.Models;

namespace Weekly_Shopping.Data
{
    public class MealPlannerContext:DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options):base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingList>()
                .HasMany(e => e.Meals)
                .WithMany();
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<Food> Foods { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
    }
}
