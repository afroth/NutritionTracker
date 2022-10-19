using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients.Delete
{
    public partial class IngredDeletePage : ComponentBase
    {
        private readonly string responseError;
        private readonly IMediator _mediator;
        private List<Ingredient> Ingredients = new List<Ingredient>();

        //*******************************************************************************
        public IngredDeletePage(IMediator mediator)
        {
            _mediator = mediator;
        }

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
