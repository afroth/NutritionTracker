using System;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Data;
using NutritionTrackerServer.Ingredients.Commands;
using System.Threading;
using Shared.Models;

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
            Ingredient ingredient = new Ingredient
            {
                IngredientName = request.IngredientName,
                Calories = request.Calories,
                Fats = request.Fats,
                Protein = request.Protein,
                Sugar = request.Sugar,
                Carbs = request.Carbs,
            };

            try
            {
                _db.Ingredient.Add(ingredient);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return ingredient;
        }
    }
}
