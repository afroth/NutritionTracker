using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Data;
using Shared.Models;

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
                Id = request.Id,
                IngredientName = request.IngredientName,
                Calories = request.Calories,
                Fats = request.Fats,
                Protein = request.Protein,
                Sugar = request.Sugar,
                Carbs = request.Carbs,
            };

            try
            {

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            return ingredient;
        }
    }
}
