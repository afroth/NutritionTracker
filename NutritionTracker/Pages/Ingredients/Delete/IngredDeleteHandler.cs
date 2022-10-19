using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Data;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients.Delete
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
