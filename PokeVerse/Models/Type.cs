using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Models
{
    public class Type : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        public Type(string name)
        {
            Name = name; 
        }
    }
}
