using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionTrackerServer.Ingredients.Queries;
using NutritionTrackerServer.Models;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionTrackerServer.Ingredients.Controllers
{
    [Route("ingredients")]
    [ApiController]
    public class IngredController : ControllerBase
    {
        private readonly IMediator _mediatr;

        // constructor
        public IngredController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        //*******************************************************************************
        // GET /ingredients
        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var query = new IngredListQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        //*******************************************************************************
        // GET api/<ValuesController>/5
        // gets the ingredient by name
        [HttpGet("{ingredient}")]
        public async Task<Ingredient> GetAsync(Ingredient ingredient)
        {
            var query = new IngredByNameQuery(ingredient);
            var result = await _mediatr.Send(query);

            return (Ingredient)(result != null ? (IActionResult) Ok(result) : NotFound());
        }

        //*******************************************************************************
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        //*******************************************************************************
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
