using MouthFull.Domain.Abstracts;
using System;
using System.Collections.Generic;

namespace MouthFull.Domain
{

    public class Recipe
    {
        public int id { get; set; }
        public string image { get; set; }
        public int missedIngredientCount { get; set; }
        public Missedingredient[] missedIngredients { get; set; }
        public string title { get; set; }
        public Unusedingredient[] unusedIngredients { get; set; }
        public int usedIngredientCount { get; set; }
        public Usedingredient[] usedIngredients { get; set; }

        public bool Favorite { get; set; }
        public string Comment { get; set; }
    }
}
