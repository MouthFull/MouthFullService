using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouthFull.Domain.Abstracts
{
    public abstract class AIngredient
    {
        public int id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
    }
}
