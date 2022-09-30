using MediatR;
using NutritionTracker.Models;

namespace NutritionTracker.Pages.Ingredients.Commands
{
    public class IngredDeleteCommand : IRequest<Ingredient>
    {
        public string IngredientName { get; set; }
       
        public IngredDeleteCommand(Ingredient newIngredient)
        {
            IngredientName = newIngredient.ingredientName;    
        }
    }
}
