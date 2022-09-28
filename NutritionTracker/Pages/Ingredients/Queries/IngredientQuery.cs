using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTracker.Models;
using NutritionTracker.Data;

namespace NutritionTracker.Queries
{
    public class IngredientQuery : IRequest<List<Ingredient>>
    {
      
    }
}
