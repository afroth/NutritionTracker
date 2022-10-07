using System.Threading.Tasks;
using NutritionTrackerServer.Data;
using MediatR;
using NutritionTrackerServer.Ingredients.Queries;
using NutritionTrackerServer.Models;
using System.Threading;

namespace NutritionTrackerServer.Ingredients.Handlers
{
    public class IngredGetByIdHandler : IRequestHandler<IngredGetByIdQuery, Ingredient>
    {
        private readonly IngredientDbContext _db;

        public IngredGetByIdHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredGetByIdQuery request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                Id = request.id,

            };
            return await _db.Ingredient.FindAsync(ingredient.Id);
        }
    }
}
