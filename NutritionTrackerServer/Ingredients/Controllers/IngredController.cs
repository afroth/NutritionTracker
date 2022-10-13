using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackerServer.Ingredients.Queries;
using NutritionTrackerServer.Ingredients.Commands;
using NutritionTrackerServer.Ingredients.Validation;
using NutritionTrackerServer.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace NutritionTrackerServer.Ingredients.Controllers
{
    [Route("ingredients")]
    [ApiController]
    public class IngredController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IngredValidation _validation;

        //*******************************************************************************
        // constructor
        public IngredController(IMediator mediatr, IngredValidation validation)
        {
            _mediatr = mediatr;
            _validation = validation;
        }

        //*******************************************************************************
        // GET /ingredients
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllIngredients()
        {
            //query a list of all the ingreidents in the db
            var result = await _mediatr.Send(new IngredListQuery());
            return Ok(result);
        }

        //*******************************************************************************
        // POST /ingredients
        [HttpPost]
        public async Task<IActionResult> CreateNewIngredient(Ingredient ingredient)
        {
            var doesIngredExist = _validation.IngredientExists(ingredient);

            if (doesIngredExist.Result == true) { return Ok(true); }
            // adding a new ingredient into the db
            //var result = 
            await _mediatr.Send(new IngredAddCommand(ingredient));

            return Ok(false);
        }

        //*******************************************************************************
        // PUT /ingredients
        [HttpPut]
        public async Task<IActionResult> UpdateIngredient(Ingredient updatedIngredient)
        {
            // get the ingredient from the database tha matches the one passed in
            var query = await _mediatr.Send(new IngredGetByIdQuery(updatedIngredient));

            // assigning the values of the passed in object to the queried 
            query.IngredientName = updatedIngredient.IngredientName;
            query.Calories = updatedIngredient.Calories;
            query.Fats = updatedIngredient.Fats;
            query.Protein = updatedIngredient.Protein;
            query.Sugar = updatedIngredient.Sugar;
            query.Carbs = updatedIngredient.Carbs;
            
            // update the object in the db
            await _mediatr.Send(new IngredUpdateCommand(query));

            return NoContent();
        }

        //*******************************************************************************
        // GET ingredients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredById(int id)
        {
            // assigning the id passed in to a object for query
            var ingredient = new Ingredient{ Id = id};
            // return the object queried by id passed in
            return  await _mediatr.Send(new IngredGetByIdQuery(ingredient));

        }

        //*******************************************************************************
        // DELETE ingredients/{id}
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteIngredById(int id)
        {
            // assigning the id passed in to a object for query
            var ingredient = new Ingredient{ Id = id};
            //object queried by id passed in
            ingredient = await _mediatr.Send(new IngredGetByIdQuery(ingredient));
            //delete the queried object from the database
            await _mediatr.Send(new IngredDeleteCommand(ingredient));

            return NoContent();
        }
    }
}