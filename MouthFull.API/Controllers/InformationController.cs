using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MouthFull.Domain;
using MouthFull.Domain.Models;
using MouthFull.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace MouthFull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IHttpClientFactory _httpclientfactory;

        private readonly MouthFullContext _mouthfullcontext;

        public InformationController(IHttpClientFactory httpClientFactory, MouthFullContext mouthfullcontext)
        {
            _httpclientfactory = httpClientFactory;
            _mouthfullcontext = mouthfullcontext;
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> Get(string recipeId)
        {
            // Endpoint 
            // Docs:
            // https://spoonacular.com/food-api/docs#Summarize-Recipe
            // Endpoint: 
            // https://api.spoonacular.com/recipes/4632/summary

            System.Diagnostics.Debug.WriteLine(recipeId);

            var ingredienturl = "https://api.spoonacular.com/recipes/";
            var summary = "/information";
            var apikey = "apiKey=f952296425454efe844155189903b15d";
            var request = $"{ingredienturl}{recipeId}{summary}?{apikey}";
            var client = _httpclientfactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(request);
            System.Text.Json.JsonDocument recipeInfo;

            if (response.IsSuccessStatusCode)
            {
                recipeInfo = await response.Content.ReadFromJsonAsync<System.Text.Json.JsonDocument>();
                // recipe.summary = Regex.Replace(recipe.summary, "<.*?>", String.Empty); ;
                // _mouthfullcontext.RecipeSummaries.Add(recipe);
                // _mouthfullcontext.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return new JsonResult(recipeInfo);

        }

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
