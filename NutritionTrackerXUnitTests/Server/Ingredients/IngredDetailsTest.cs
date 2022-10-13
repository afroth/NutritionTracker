using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionTrackerXUnitTests.Server.Ingredients
{
    public class IngredDetailsTest
    {
        private readonly SliceFixture _fixture;

        public IngredDetailsTest(SliceFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task Should_query_for_details()
        {
            //var chocolate = await _fixture.SendAsync(new CreateEdit.Command
            //{
            //    Ingredientname = "George",
            //    LastName = "Costanza",
            //    HireDate = DateTime.Today
            //});
        }
    }
}
