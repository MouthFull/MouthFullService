using Microsoft.AspNetCore.Mvc;
using MouthFull.Domain;
using MouthFull.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace MouthFull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public readonly IHttpClientFactory _httpclientfactory;

        public RecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpclientfactory = httpClientFactory;
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> Get(string RecipeId)
        {
            // Endpoint 
            // Docs:
            // https://spoonacular.com/food-api/docs#Summarize-Recipe
            // Endpoint: 
            // https://api.spoonacular.com/recipes/4632/summary

            System.Console.WriteLine("RecipeId: " + RecipeId);
            
            var ingredienturl = "https://api.spoonacular.com/recipes/";
            var summary = "/summary";
            var apikey = "apiKey=f952296425454efe844155189903b15d";
            var request = $"{ingredienturl}{RecipeId}{summary}?{apikey}";
            var client = _httpclientfactory.CreateClient();
            
            HttpResponseMessage response = await client.GetAsync(request);
            RecipeSummary recipe;   
                        
            if (response.IsSuccessStatusCode)
            {
                recipe = await response.Content.ReadFromJsonAsync<RecipeSummary>();
                System.Console.WriteLine(recipe);
            }
            else
            {
                return BadRequest();
            }

            return new JsonResult(recipe);
            
        }

        // POST api/<MouthfullController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MouthfullController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MouthfullController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
