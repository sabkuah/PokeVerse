using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Pokemon : BaseEntity
    {
  
        public string Name { get; set; }

        public string Type0 { get; set; }

        public string Type1 { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Speed { get; set; }
    }
}
