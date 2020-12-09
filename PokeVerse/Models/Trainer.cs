using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Trainer : BaseEntity
    {
    
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }

        //public Trainer(string username, string email, DateTime dateJoined)
        //{
        //    UserName = username;
        //    Email = email;
        //    DateJoined = dateJoined;
        //}
    }
}