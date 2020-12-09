using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Trainer : BaseEntity
    {
        public int TrainerId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
    }
}