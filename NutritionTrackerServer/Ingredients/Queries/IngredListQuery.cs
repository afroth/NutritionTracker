using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Models;
using NutritionTrackerServer.Data;

namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredListQuery : IRequest<List<Ingredient>>
    {
      
    }
}

