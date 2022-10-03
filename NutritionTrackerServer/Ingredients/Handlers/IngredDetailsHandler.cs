using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerServer.Data;
using NutritionTrackerServer.Models;
using NutritionTrackerServer.Ingredients.Queries;

namespace NutritionTrackerServer.Ingredients.Handlers
{
    public class IngredDetailsHandler : IRequestHandler<IngredListQuery, List<Ingredient>>
    {
        private readonly IngredientDbContext _db;

        public IngredDetailsHandler(IngredientDbContext db )
        {
            _db = db;
        }


        public Task<List<Ingredient>> Handle(IngredListQuery request, CancellationToken cancellationToken)
        {
            return _db.Ingredient.ToListAsync();

        }
    }
}
