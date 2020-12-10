using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Pokemon : BaseEntity
    {

        public int PokeNumber { get; set; }
        public string Name { get; set; }

        public string Type0 { get; set; }

        public string Type1 { get; set; }

        //public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Speed { get; set; }

        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
        public virtual ICollection<PokedexPokemon> PokedexPokemon { get; set; }



        public Pokemon(int pokeNumber, string name, string type0, string type1, int attack, int defense, int speed)
        {
            PokeNumber = pokeNumber;
            Name = name;
            Type0 = type0;
            Type1 = type1;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            
        }

    }
}
