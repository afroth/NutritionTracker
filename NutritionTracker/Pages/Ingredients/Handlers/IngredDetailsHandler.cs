using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Queries;

namespace NutritionTracker.Handlers
{
    public class IngredDetailsHandler : IRequestHandler<IngredientQuery, List<Ingredient>>
    {
        private readonly IngredientDbContext _db;

        public IngredDetailsHandler(IngredientDbContext db )
        {
            _db = db;
        }


        public Task<List<Ingredient>> Handle(IngredientQuery request, CancellationToken cancellationToken)
        {
            return _db.Ingredient.ToListAsync();

        }
    }
}
