using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutritionTracker.Models;

namespace NutritionTracker.Data
{
    public class IngredientDbContext : DbContext
    {
        public IngredientDbContext(DbContextOptions<IngredientDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ingredient> Ingredient { set; get; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(GetIngredients());
            base.OnModelCreating(modelBuilder);
        }

        private List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient {ingredientName = "Eggs", calories = 90, fats = 10, protein = 20, sugar = 0, carbs = 0},
                new Ingredient {ingredientName = "Tuna Fish", calories = 60, fats = 0, protein = 36, sugar = 0, carbs = 0},
                new Ingredient {ingredientName = "Oat Meal", calories = 120, fats = 5, protein = 8, sugar = 0, carbs = 45}
            };
        }
    }
}
