using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NutritionTracker.Models;

namespace NutritionTracker.Pages.Ingredients.Services
{
    public class IngredServices
    {
        private readonly IHttpClientFactory _clientFactory;

        Ingredient selectedIngredient = new Ingredient();
        string responseError;

        //*******************************************************************************
        public IngredServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        //*******************************************************************************
        public async Task<List<Ingredient>> RefreshIngredients()
        {
            // the localhost address is "local" can be found in appsettings.json
            var client = _clientFactory.CreateClient("local");

            try
            {
                //  GET call to Api to return a list of all the ingredients in the database.
                return await client.GetFromJsonAsync<List<Ingredient>>("ingredients");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*******************************************************************************
        public async Task<Ingredient> GetIngredientById(int id)
        {
            // the localhost address is "local" can be found in appsettings.json
            var client = _clientFactory.CreateClient("local");
            try
            {
                // GET Api call to get the selected ingredient in the drop down list on razor page.
                selectedIngredient = await client.GetFromJsonAsync<Ingredient>($"ingredients/{id}");
                // resetting value of Error message.
                responseError = null;

                return selectedIngredient;
            }
            catch (Exception ex)
            {
                // captures exeption message in responseError string.
                responseError = $"Ingredient GET by Id error: {ex.Message}";
                throw ex;
            }
        }

        //*******************************************************************************
        public async Task DeleteIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            var client = _clientFactory.CreateClient("local");

            try
            {
                // DELETE call to Api to delete an Ingredient by the Id passed in
                await client.DeleteAsync($"ingredients/{ingredient.Id}");
                // resetting value of Error message.
                responseError = null;
               
            }
            catch (Exception ex)
            {
                // captures exeption message in responseError string.
                responseError = $"Ingredient delete error: {ex.Message}";
            }

        }

        //*******************************************************************************
        public async Task AddNewIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            var client = _clientFactory.CreateClient("local");

            try
            {
                //POST call to Api to Add an Ingredient to the db
                await client.PostAsJsonAsync($"ingredients", ingredient);
                // resetting value of Error message.
                responseError = null;
            }
            catch (Exception ex)
            {
                // captures exeption message in responseError string.
                responseError = $"Ingredient Add error: {ex.Message}";
            }

        }

        //*******************************************************************************
        public async Task UpdateIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            var client = _clientFactory.CreateClient("local");

            try
            {
                //POST call to Api to Add an Ingredient to the db
                await client.PutAsJsonAsync($"ingredients", ingredient);
                // resetting value of Error message.
                responseError = null;
            }
            catch (Exception ex)
            {
                // captures exeption message in responseError string.
                responseError = $"Ingredient Update error: {ex.Message}";
            }

        }
    }
}
