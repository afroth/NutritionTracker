using System;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Data;
using NutritionTrackerServer.Models;
using NutritionTrackerServer.Ingredients.Commands;
using System.Threading;

namespace NutritionTrackerServer.Ingredients.Handlers
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
