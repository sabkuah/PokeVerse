using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class PokedexPokemon
    {
        [Key,Column(Order=0)]
        public int PokedexId { get; set; }

        [Key, Column(Order = 1)]
        public int PokemonId { get; set; }


        public virtual Pokedex Pokedex { get; set; }
        public virtual Pokemon Pokemon { get; set; }

        public PokedexPokemon (int pokedexId, int pokemonId)
        {
            PokedexId = pokedexId;
            PokemonId = pokemonId;
        }

    }
}
