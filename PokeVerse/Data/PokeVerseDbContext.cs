using Microsoft.EntityFrameworkCore;
using PokeVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeVerse.Data
{
    public class PokeVerseDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        


    }
}
