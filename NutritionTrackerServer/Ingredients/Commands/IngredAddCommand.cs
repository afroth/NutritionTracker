using MediatR;
using Shared.Models;

namespace NutritionTrackerServer.Ingredients.Commands
{

    public class IngredAddCommand : IRequest<Ingredient>
    {
        public string IngredientName { get; set; }
        public int Calories { get; set; }
        public int Fats { get; set; }
        public int Protein { get; set; }
        public int Sugar { get; set; }
        public int Carbs { get; set; }

        //*******************************************************************************
        // constructor
        public IngredAddCommand(Ingredient ingredient)
        {
            IngredientName =  ingredient.IngredientName;
            Calories = ingredient.Calories;
            Fats = ingredient.Fats;
            Protein = ingredient.Protein;
            Sugar = ingredient.Sugar;
            Carbs = ingredient.Carbs;
        }
    }
}
