using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Pages.Ingredients.Queries;

namespace NutritionTracker.Pages.Ingredients
{
    public class UpdateController
    {
        
        private readonly IMediator _mediatr;
        private Ingredient returnedData { get; set;}
        
        public UpdateController(IMediator mediator) => _mediatr = mediator;

        //*******************************************************************************
        public  async Task<Ingredient> GetIngredientData(Ingredient passedInData)
        {
           return await Task.FromResult (returnedData = await _mediatr.Send(new IngredByNameQuery(passedInData)));
         
        }

        public  Ingredient SendDataBack()
        {        
            return returnedData;
        }

       
    }
}
