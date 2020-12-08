using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Pokedex : BaseEntity
    {
        public virtual int TrainerId { get; private set; }

        public Pokedex(int trainerid)
        {
            TrainerId = trainerid; 
        }

    }
}
