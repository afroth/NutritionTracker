using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutritionTracker.Models;
using NutritionTracker.Pages;
using Microsoft.EntityFrameworkCore;


namespace NutritionTracker.Data
{
    public class IngredientService
    {

        private IngredientDbContext dbContext;

        //*******************************************************************************
        public IngredientService(IngredientDbContext dbContext)
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
        // add to database
        //public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        //{
        //    try
        //    {
        //        dbContext.Ingredient.Add(ingredient);
        //        await dbContext.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return ingredient;
        //}

        //*******************************************************************************
        // update database to database
        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            try
            {
                var ingredientExist = dbContext.Ingredient.FirstOrDefault(o => o.ingredientName.Equals(ingredient.ingredientName, StringComparison.OrdinalIgnoreCase));
                if (ingredientExist != null)
                {
                    dbContext.Update(ingredient);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingredient;
        }
        //*******************************************************************************
        // delete from database
        //public async Task DeleteIngredientAsync(Ingredient ingredient)
        //{
        //    try
        //    {
        //        dbContext.Ingredient.Remove(ingredient);
        //        await dbContext.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    } //end class     
}// end namespace
