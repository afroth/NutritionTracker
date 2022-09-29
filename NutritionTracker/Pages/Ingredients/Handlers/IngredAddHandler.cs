﻿using System;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Pages.Ingredients.Commands;
using System.Threading;

namespace NutritionTracker.Pages.Ingredients.Handlers
{
    public class IngredAddHandler : IRequestHandler<IngredAddCommand, Ingredient>
    {
        private readonly IngredientDbContext _db;

        public IngredAddHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredAddCommand request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                ingredientName = request.IngredientName,
                calories = request.Calories,
                fats = request.Fats,
                protein = request.Protein,
                sugar = request.Sugar,
                carbs = request.Carbs,
            };

            try
            {
                _db.Ingredient.Add(ingredient);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return ingredient;
        }     
    }   
}
