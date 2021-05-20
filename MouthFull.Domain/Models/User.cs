using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouthFull.Domain.Models
{
    public class User
    {
        public int EntityId { get; set; }
        public List<Recipe> History { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}