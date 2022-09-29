using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Models;

namespace NutritionTracker.Pages.Ingredients.Queries
{
    public class IngredientByNameQuery : IRequest<Ingredient>
    {
        public string IngredientName { get; set; }
        
        //*******************************************************************************
        // constructor
        public IngredientByNameQuery(Ingredient ingredient)
        {
            IngredientName = ingredient.ingredientName;           
        }
    }
}
