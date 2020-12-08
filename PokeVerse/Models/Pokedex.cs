using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Pokedex : BaseEntity
    {

        [ForeignKey("TrainerId")]
        public int TrainerId { get; set; }


        public Pokedex(int trainerId)
        {
            TrainerId = trainerId;
        }

    }
}
