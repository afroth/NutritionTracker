using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTracker.Commands;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Queries;


namespace NutritionTracker.Handlers
{
    //public class IngredDeleteHandler : IRequestHandler<IngredientCommand, Ingredient>
    //{

    //    private readonly IngredientDbContext _db;

    //    public IngredDeleteHandler(IngredientDbContext db)
    //    {
    //        _db = db;
    //    }


    //    public async Task<Ingredient> Handle(IngredientCommand request, CancellationToken cancellationToken)
    //    {
    //        var ingredient = await _db.Ingredient.FindAsync(Ingredient);
    //        return _db.Ingredient.Remove(Ingredient);
    //    }
    //}
}
