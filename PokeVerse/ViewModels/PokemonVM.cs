using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeVerse.Models;

namespace PokeVerse.ViewModels
{
    public class PokemonVM
    {
        public int Id { get; set; }
        public int PokeNumber { get; set; }
        public string Name { get; set; }
        public string Type0 { get; set; }
        public string Type1 { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string ImageUrl { get; set; }

    }
}
