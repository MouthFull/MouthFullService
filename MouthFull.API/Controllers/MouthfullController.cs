using Microsoft.AspNetCore.Mvc;
using MouthFull.Domain;
using MouthFull.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MouthFull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouthfullController : ControllerBase
    {
        // GET: api/<MouthfullController>
        [HttpGet]
        public JsonResult Get()
        {

            var ingredients = new List<Ingredient> { new Ingredient { id = 5, name = "apple" }, new Ingredient {id = 6, name="banana" } };
            return new JsonResult(ingredients);
        }

        // GET api/<MouthfullController>/string
        [HttpGet("{string}")]
        public string Get(string ingredients)
        {
            return "value";
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
