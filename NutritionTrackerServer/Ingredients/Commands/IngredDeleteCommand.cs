using MediatR;
using NutritionTrackerServer.Models;

namespace NutritionTrackerServer.Ingredients.Commands
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
