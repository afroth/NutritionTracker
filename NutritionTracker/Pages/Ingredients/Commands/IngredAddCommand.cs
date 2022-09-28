using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Models;

namespace NutritionTracker.Pages.Ingredients.Commands
{
    public class IngredAddCommand : IRequest
    {
        
        public string ingredientName { get; set; } 
        public int calories { get; set; }   
        public int fats { get; set; }     
        public int protein { get; set; }
        public int sugar { get; set; }
        public int carbs { get; set; }
    }
}
