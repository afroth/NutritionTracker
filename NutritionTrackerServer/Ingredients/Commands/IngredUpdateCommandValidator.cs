using FluentValidation;

namespace NutritionTrackerServer.Ingredients.Commands
{
    public class IngredUpdateCommandValidator : AbstractValidator<IngredUpdateCommand>
    {
        public IngredUpdateCommandValidator()
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
