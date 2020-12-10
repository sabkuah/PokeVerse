using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokeVerse.Data;
using PokeVerse.Models;

namespace PokeVerse.Pages.Pokedex
{
    public class IndexModel : PageModel
    {
        private readonly PokeVerseDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public IndexModel(PokeVerseDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        public Models.Pokedex Pokedex { get; set; }

        public ICollection<PokedexPokemon> PokemonList { get; private set; }




        public void OnGet()
        {
            System.Threading.Thread.Sleep(2000);

            Pokedex = _db.PokeDex
                .Include(p => p.PokedexPokemons)
                .ThenInclude(pp => pp.Pokemon)
                .Where(p=> p.Id == (int)HttpContext.Session.GetInt32("Id") )
            .FirstOrDefault();

            PokemonList = Pokedex.PokedexPokemons;

            _db.PokeDex.Update(Pokedex);
            _db.SaveChanges();

        }
    }
}
