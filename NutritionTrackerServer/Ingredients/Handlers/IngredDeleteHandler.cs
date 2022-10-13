using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Data;
using Shared.Models;

namespace NutritionTrackerServer.Ingredients.Handlers
{
    public class IngredDeleteHandler : IRequestHandler<IngredDeleteCommand, Ingredient>
    {
        private readonly IngredientDbContext _db;

        public IngredDeleteHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredDeleteCommand request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                Id = request.Id,
            };

            var removeIngredient = await _db.Ingredient.FindAsync(ingredient.Id);

            try
            {
                _db.Ingredient.Remove(removeIngredient);
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
