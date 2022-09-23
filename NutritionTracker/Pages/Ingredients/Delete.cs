using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutritionTracker.Data;
using NutritionTracker.Models;

using Microsoft.EntityFrameworkCore;

namespace NutritionTracker.Pages.Ingredients
{
    public class Delete
    {
        private IngredientDbContext dbContext;
       // public Ingredient NewIngredient { get; set; } = new Ingredient();

        
        //*******************************************************************************
        public Delete(IngredientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //*******************************************************************************
        // get from database
        public async Task<List<Ingredient>> GetIngredientAsync()
        {
            return await dbContext.Ingredient.ToListAsync();
        }

        //*******************************************************************************
        public async Task DeleteIngredientAsync(Ingredient ingredient)
        {
            try
            {
                dbContext.Ingredient.Remove(ingredient);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }// end class
}// end namespace
