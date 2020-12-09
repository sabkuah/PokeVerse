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
        //Default Ctor
        public PokeVerseDbContext(DbContextOptions<PokeVerseDbContext> options) : base(options)
        {
        }
        
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Models.Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonType>()
                .HasKey(pt => new { pt.TypeId, pt.PokemonId });
            //this defines that the combination of these two properties as a primary key for the PokemonType table 

            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Type)
                .WithMany(p => p.PokemonTypes)
                .HasForeignKey(fk => new { fk.TypeId });
            //defines the relationship and defines the foreign key


            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Pokemon)
                .WithMany(p => p.PokemonTypes)
                .HasForeignKey(fk => new { fk.PokemonId });
            //defines the relationship and defines the foreign key

        }
    }
}
