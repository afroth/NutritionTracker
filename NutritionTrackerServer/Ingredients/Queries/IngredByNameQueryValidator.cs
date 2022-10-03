﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredByNameQueryValidator : AbstractValidator<IngredByNameQuery>
    {
        public IngredByNameQueryValidator()
        {
            RuleFor(x => x.IngredientName).NotNull();
        }

    }
}
