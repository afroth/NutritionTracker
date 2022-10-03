using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Models;
using NutritionTrackerServer.Data;

namespace NutritionTrackerServer.Ingredients.Handlers
{

    public class IngredUpdateHandler : IRequestHandler<IngredUpdateCommand, Ingredient>
    {

        private readonly IngredientDbContext _db;

        public IngredUpdateHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredUpdateCommand request, CancellationToken cancellationToken)
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
