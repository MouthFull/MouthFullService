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
    public class MouthfullController : ControllerBase
    {
        public readonly IHttpClientFactory _httpclientfactory;
        // GET: api/<MouthfullController>

        public MouthfullController(IHttpClientFactory httpClientFactory)
        {
            _httpclientfactory = httpClientFactory;
        }
        //[HttpGet]
        //public JsonResult Get()
        //{

        //    var ingredients = new List<Ingredient> { new Ingredient { id = 5, name = "apple" }, new Ingredient {id = 6, name="banana" } };
        //    var recipe = new Recipe();
        //    recipe.Neededingredients = ingredients;
        //    return new JsonResult(recipe);
        //}

        // GET api/<MouthfullController>/string
        [HttpGet("{ingredients}")]
        public async Task<IActionResult> Get(string ingredients)
        {
            var ingredienturl = "https://api.spoonacular.com/recipes/findByIngredients?ingredients=";
            var apikey = "apiKey=f952296425454efe844155189903b15d";
            var numberrecipe = "number=5";
            var request = $"{ingredienturl}{ingredients}&{numberrecipe}&{apikey}";
            var client = _httpclientfactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(request);
            List<Recipe> recipes;
            if (response.IsSuccessStatusCode)
            {
                recipes = await response.Content.ReadFromJsonAsync<List<Recipe>>();
            }
            else
            {
                return BadRequest();
            }

            return new JsonResult(recipes);
            
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
