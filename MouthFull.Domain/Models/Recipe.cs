using System;
using System.Collections.Generic;

namespace MouthFull.Domain
{

    public class Recipe
    {

        public int id { get; set; }
        public string image { get; set; }
        public int missedIngredientCount { get; set; }
        public List<Ingredient> missedIngredients { get; set; }
        public string title { get; set; }
        public List<Ingredient> unusedIngredients { get; set; }
        public int usedIngredientCount { get; set; }
        public List<Ingredient> usedIngredients { get; set; }

        public bool Favorite { get; set; }
        public string Comment { get; set; }
        public int EntityId { get; set; }
    }
}
