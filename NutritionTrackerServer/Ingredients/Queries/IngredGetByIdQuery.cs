using MediatR;
using Shared.Models;

namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredGetByIdQuery : IRequest<Ingredient>
    {
        public int Id { get; set; }

        //*******************************************************************************
        // constructor
        public IngredGetByIdQuery(Ingredient ingredient)
        {
            Id = ingredient.Id;
        }
    }
}
