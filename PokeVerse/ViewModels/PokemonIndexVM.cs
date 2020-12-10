using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokeVerse.ViewModels
{
    public class PokemonIndexVM
    {
        public List<PokemonVM> Pokemons { get; set; }
        public List<SelectListItem> Types { get; set; }
        public string TypesFilterApplied { get; set; }
    }
}
