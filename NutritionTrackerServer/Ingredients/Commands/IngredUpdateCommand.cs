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
        public int Id { get; set; }
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
            Id = ingredient.Id;
            IngredientName = ingredient.IngredientName;
            Calories = ingredient.Calories;
            Fats = ingredient.Fats;
            Protein = ingredient.Protein;
            Sugar = ingredient.Sugar;
            Carbs = ingredient.Carbs;
        }
    }
}
