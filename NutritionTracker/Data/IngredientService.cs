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
        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            try
            {
                dbContext.Ingredient.Add(ingredient);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return ingredient;
        }

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


        //List<Ingredient> ingredientList = new List<Ingredient>();

        ////*******************************************************************************
        //// adds the new ingredient to the list of ingredients
        //public void addIngredient(Ingredient o)
        //{
        //    ingredientList.Add(o);
        //}

        ////*******************************************************************************
        //// removes the ingredient based on the name of ingredient passed in.
        //public void removeIngredient(string name)
        //{
        //    // assigns a bool value based on if there are any matches found in function call
        //    // ingredientNameCheck.
        //    bool ingredientExists = ingredientNameCheck(name);

        //   // if thereis no matches do nothing
        //    if (ingredientExists == false) { }

        //    // if there is a match remove all matches.
        //    else ingredientList.RemoveAll(o => o.ingredientName == name);
        //}

        ////*******************************************************************************
        ////finds all object matches of the ingredient name in the List
        //public bool ingredientNameCheck(string name)
        //{
        //    // finds all matches in the list where the objects have the same ingredient name;
        //    var matches = ingredientList.Where(o => o.ingredientName == name);

        //    // return true if there are matches
        //    if (matches != null) { return true; }

        //    return false;
        //}

    } //end class     
}// end namespace
