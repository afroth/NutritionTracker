using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NutritionTracker.Models;


namespace NutritionTracker.Pages.Ingredients
{
    public partial class IngredientAdd : ComponentBase
    {
        private Ingredient Ingredient { get; set; } = new Ingredient();
       // private bool doesIngredExist;

        //*******************************************************************************
        private async Task AddNewIngredient()
        {
             // uses service IngredServices injected on razor page to add new Ingredient to db
             await service.AddNewIngredient(Ingredient);
            //Refresh the component to clear boxes
            StateHasChanged();
        }
        
    }
}
