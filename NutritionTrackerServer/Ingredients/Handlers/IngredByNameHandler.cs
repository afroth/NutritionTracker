using System.Threading.Tasks;
using NutritionTrackerServer.Data;
using MediatR;
using NutritionTrackerServer.Ingredients.Queries;
using NutritionTrackerServer.Models;
using System.Threading;

namespace NutritionTrackerServer.Ingredients.Handlers
{
    public class IngredByNameHandler : IRequestHandler<IngredByNameQuery, Ingredient>
    {
        private readonly IngredientDbContext _db;

        public IngredByNameHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredByNameQuery request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                ingredientName = request.IngredientName,

            };
            return await _db.Ingredient.FindAsync(ingredient);
        }
    }
}
