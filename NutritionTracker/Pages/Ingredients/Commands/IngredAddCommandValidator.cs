using FluentValidation;

namespace NutritionTracker.Pages.Ingredients.Commands
{
    public class IngredAddCommandValidator : AbstractValidator<IngredAddCommand>
    {
        public IngredAddCommandValidator()
        {
            RuleFor(x => x.IngredientName).NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Calories).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Fats).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Protein).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Sugar).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Carbs).NotNull().GreaterThanOrEqualTo(0);
        }

    }
}
