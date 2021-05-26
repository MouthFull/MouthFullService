using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MouthFull.Domain;
using MouthFull.Domain.Models;
using MouthFull.Storage;
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
  public class HistoryController : ControllerBase
  {
    public MouthFullContext _mouthFullContext;
    public HistoryController(MouthFullContext mouthFullContext)
    {
      _mouthFullContext = mouthFullContext;
    }

    // GET api/<MouthfullController>/string
    [HttpGet]
    public JsonResult Get()
    {
      var _context = _mouthFullContext;
      var recipes = _context.RecipeSummaries.Include(r => r.EntityId > 0);
      System.Console.WriteLine("Recipes: " + recipes);
      return new JsonResult(recipes);

    }

    // POST api/<MouthfullController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<MouthfullController>/5
    [HttpPut]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<MouthfullController>/5
    [HttpDelete]
    public void Delete(int id)
    {
    }
  }
}
