using System;
using System.Collections.Generic;
using NutritionTrackerServer.Ingredients.Queries;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Models;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NutritionTrackerServer.Ingredients.Validation
{
    public class IngredValidation
    {
        private readonly IMediator _mediatr;

        public IngredValidation(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        
        // checks if another ingredient with the same name exists in the database.
        public async Task<bool> IngredientExists(Ingredient ingredient)
        {
            var result = await _mediatr.Send(new IngredListQuery());

            if (result.Any(i => i.IngredientName == ingredient.IngredientName)) {
                return true;
            }

            return false;
               
        }

    }// end class
}// end namespace
