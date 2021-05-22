using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MouthFull.Domain.Models
{

    public class Recipe
    {

        public int id { get; set; }
        public string image { get; set; }
        [NotMapped]
        public int missedIngredientCount { get; set; }
        [NotMapped]
        public List<Ingredient> missedIngredients { get; set; }
        public string title { get; set; }
        [NotMapped]
        public List<Ingredient> unusedIngredients { get; set; }
        [NotMapped]
        public int usedIngredientCount { get; set; }
        [NotMapped]
        public List<Ingredient> usedIngredients { get; set; }

        public bool Favorite { get; set; }
        public string Comment { get; set; }
        public int EntityId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
