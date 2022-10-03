using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Models;

namespace NutritionTrackerServer.Ingredients.Commands
{
    public class IngredUpdateCommand : IRequest<Ingredient>
    {
        public string IngredientName { get; set; }
        public int Calories { get; set; }
        public int Fats { get; set; }
        public int Protein { get; set; }
        public int Sugar { get; set; }
        public int Carbs { get; set; }

        //*******************************************************************************
        // constructor
        public IngredUpdateCommand(Ingredient ingredient)
        {
            IngredientName = ingredient.ingredientName;
            Calories = ingredient.calories;
            Fats = ingredient.fats;
            Protein = ingredient.protein;
            Sugar = ingredient.sugar;
            Carbs = ingredient.carbs;
        }
    }
}
