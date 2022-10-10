﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredGetByIdValidator : AbstractValidator<IngredGetByIdQuery>
    {
        public IngredGetByIdValidator()
        {
            RuleFor(x => x.id).NotNull();
        }

    }
}
