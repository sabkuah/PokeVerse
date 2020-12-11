using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Pokedex : BaseEntity
    {
        public string TrainerId { get; set; }
        public virtual ICollection<PokedexPokemon> PokedexPokemons { get; set; }

        public Pokedex(string trainerId)
        {
            TrainerId = trainerId;
        }

    }
}
