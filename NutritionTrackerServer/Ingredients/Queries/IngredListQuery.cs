using System.Collections.Generic;
using MediatR;
using Shared.Models;

namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredListQuery : IRequest<List<Ingredient>>
    {

    }
}

