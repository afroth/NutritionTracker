using MediatR;
using Shared.Models;

namespace NutritionTrackerServer.Ingredients.Commands
{
    public class IngredDeleteCommand : IRequest<Ingredient>
    {
        public int Id { get; set; }

        public IngredDeleteCommand(Ingredient newIngredient)
        {
            Id = newIngredient.Id;
        }
    }
}
