using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients
{
    public partial class IngredientDelete : ComponentBase
    {
        private readonly string responseError;
        private List<Ingredient> Ingredients = new List<Ingredient>();

        //*******************************************************************************
        // when page originally loads this function is fired.
        protected override async Task OnInitializedAsync()
        {
            // uses service IngredServices injected on razor page to get a list of all ingredients
            Ingredients = await service.RefreshIngredients();
        }

        //*******************************************************************************
        //
        protected async Task DeleteIngredient(Ingredient ingredient)
        {
            // uses service IngredServices injected on razor page to delete a ingredient from db
            await service.DeleteIngredient(ingredient);

            // uses service IngredServices injected on razor page to get a list of all ingredients
            // refresh so table is up to date.
            Ingredients = await service.RefreshIngredients();
        }
    }
}
