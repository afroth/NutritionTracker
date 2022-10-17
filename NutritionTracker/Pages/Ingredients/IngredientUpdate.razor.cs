using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients
{
    public partial class IngredientUpdate : ComponentBase
    {
        private List<Ingredient> Ingredients { get; set; }

        private Ingredient ingredientToUpdate = new Ingredient();
        private readonly Ingredient selectedIngredient = new Ingredient();
        // string responseError;



        //*******************************************************************************
        protected override async Task OnInitializedAsync()
        {
            // gets a list of ingredients from IngredServices which calls an Api
            Ingredients = await service.RefreshIngredients();
            // assigning id from the first object in the List Ingredients to render on razor page. 
            selectedIngredient.Id = Ingredients.FirstOrDefault().Id;
            // query to get the values of the first ingredient in the List Ingredients
            await RequestSelectedIngredient();
        }

        //*******************************************************************************
        private async Task Selected(ChangeEventArgs args)
        {
            // convert the id of the selected ingredient and assign to object.id
            selectedIngredient.Id = Convert.ToInt32(args.Value);
            // to request the selected ingredient
            await RequestSelectedIngredient();
        }

        //*******************************************************************************
        private async Task UpdateIngredientData()
        {
            await service.UpdateIngredient(ingredientToUpdate);

        }

        //*******************************************************************************
        private async Task RequestSelectedIngredient()
        {
            // query to get the values of the first ingredient in the List Ingredients
            ingredientToUpdate = await service.GetIngredientById(selectedIngredient.Id);
        }
    }
}
