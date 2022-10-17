using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace NutritionTracker.Pages.Ingredients.Service
{
    public class IngredCRUDservice
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navManager;

        private Ingredient selectedIngredient = new Ingredient();
       

        //*******************************************************************************
        public IngredCRUDservice(IHttpClientFactory clientFactory,NavigationManager navManager)
        {
            _clientFactory = clientFactory;
            _navManager = navManager;
        }

        //*******************************************************************************
        public async Task<List<Ingredient>> RefreshIngredients()
        {
            // the localhost address is "local" can be found in appsettings.json
            HttpClient client = _clientFactory.CreateClient("local");

            try
            {
                //  GET call to Api to return a list of all the ingredients in the database.
                return await client.GetFromJsonAsync<List<Ingredient>>("ingredients");
               
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unsuccessful server response, reason: {ex.Message}");
            }
        }

        //*******************************************************************************
        public async Task<Ingredient> GetIngredientById(int id)
        {
            // the localhost address is "local" can be found in appsettings.json
            HttpClient client = _clientFactory.CreateClient("local");

            try
            {
                // GET Api call to get the selected ingredient in the drop down list on razor page.
                selectedIngredient = await client.GetFromJsonAsync<Ingredient>($"ingredients/{id}");
                // resetting value of Error message.
                return selectedIngredient;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unsuccessful server response, reason: {ex.Message}");
            }
        }

        //*******************************************************************************
        public async Task DeleteIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            HttpClient client = _clientFactory.CreateClient("local");

            try
            {
                // DELETE call to Api to delete an Ingredient by the Id passed in
                await client.DeleteAsync($"ingredients/{ingredient.Id}");             
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unsuccessful server response, reason: {ex.Message}");
            }
        }

        //*******************************************************************************
        public async Task<IActionResult> AddNewIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            HttpClient client = _clientFactory.CreateClient("local");
            // bool doesIngredExist;
            try
            {
                //POST call to Api to Add an Ingredient to the db
                HttpResponseMessage result = await client.PostAsJsonAsync($"ingredients", ingredient);
                return (IActionResult)result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unsuccessful server response, reason: {ex.Message}");
            }
        }

        //*******************************************************************************
        public async Task UpdateIngredient(Ingredient ingredient)
        {
            // the localhost address is "local" can be found in appsettings.json
            HttpClient client = _clientFactory.CreateClient("local");

            try
            {
                //POST call to Api to Add an Ingredient to the db
                await client.PutAsJsonAsync($"ingredients", ingredient);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unsuccessful server response, reason: {ex.Message}");
            }
        }
    }
}
