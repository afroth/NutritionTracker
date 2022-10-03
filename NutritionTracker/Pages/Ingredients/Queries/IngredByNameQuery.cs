﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Models;

namespace NutritionTracker.Pages.Ingredients.Queries
{
    public class IngredByNameQuery : IRequest<Ingredient>
    {
        public string IngredientName { get; set; }
        
        //*******************************************************************************
        // constructor
        public IngredByNameQuery(Ingredient ingredient)
        {
            IngredientName = ingredient.ingredientName;           
        }
    }
}