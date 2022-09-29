using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutritionTracker.Data;
using MediatR;
using NutritionTracker.Pages.Ingredients.Queries;
using NutritionTracker.Models;
using System.Threading;

namespace NutritionTracker.Pages.Ingredients.Handlers
{
    public class IngredByNameHandler : IRequestHandler<IngredientByNameQuery, Ingredient>
    {
        private readonly IngredientDbContext _db;

        public IngredByNameHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<Ingredient> Handle(IngredientByNameQuery request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                ingredientName = request.IngredientName,
                
            };
            return _db.Ingredient.Find(ingredient.ingredientName);
        }
    }
}
