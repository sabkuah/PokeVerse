using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class PokemonType
    {
       //this is a bridge table with a composite key
        [Key]
        public int PokemonId { get; private set; }

        [Key]
        public int TypeId { get; private set; }

        //navigation properties
        public virtual Pokemon Pokemon { get; set; }
        public virtual Type Type { get; set; }

    }
}