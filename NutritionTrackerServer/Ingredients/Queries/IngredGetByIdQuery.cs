using MediatR;
using NutritionTrackerServer.Models;

namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredGetByIdQuery : IRequest<Ingredient>
    {
        public int id { get; set; }
        
        //*******************************************************************************
        // constructor
        public IngredGetByIdQuery(Ingredient ingredient)
        {
            id = ingredient.Id;           
        }
    }
}
