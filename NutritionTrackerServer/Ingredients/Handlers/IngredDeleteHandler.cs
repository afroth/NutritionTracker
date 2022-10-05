using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Data;
using NutritionTrackerServer.Models;

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
                ingredientName = request.IngredientName, 
            };

            var removeIngredient = await _db.Ingredient.FindAsync(ingredient.ingredientName);

            try
            {
                _db.Ingredient.Remove(removeIngredient);
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
