using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients.Delete
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
