using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NutritionTracker.Models;


namespace NutritionTracker.Pages.Ingredients
{
    public partial class IngredientAdd : ComponentBase
    {
        public Ingredient ingredient { get; set; } = new Ingredient();
       

        //*******************************************************************************
        private async Task AddNewIngredient()
        {
            // uses service IngredServices injected on razor page to add new Ingredient to db
            await service.AddNewIngredient(ingredient);
            //Refresh the component to clear boxes
            StateHasChanged();
        }
        //private bool IngredientExists()
        //{

        //}
    }
}
