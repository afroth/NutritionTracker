using FluentValidation;
namespace NutritionTrackerServer.Ingredients.Queries
{
    public class IngredGetByIdValidator : AbstractValidator<IngredGetByIdQuery>
    {
        public IngredGetByIdValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }

    }
}
