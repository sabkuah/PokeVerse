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
using PokeVerse.ViewModels;

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

        public Models.Pokedex TrainerPokedex { get; set; }
        public ICollection<PokedexPokemon> PokemonList { get; private set; }

        public IActionResult OnGet(Pokemon addPokemon)
        {
            System.Threading.Thread.Sleep(2000);

            //If no new pokemon is being added, redirect to pokedex without accessing database
            if (addPokemon?.Name == null)
            {
                return RedirectToPage("/Pokedex");
            }
            else
            {
                //Finds Id of Trainer logged in

                string userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;

                //Finds Pokedex of Trainer logged in, assign to TrainerPokedex
                TrainerPokedex = _db.PokeDex
                    .Include(pp => pp.PokedexPokemons)
                    .ThenInclude(p => p.Pokemon)
                    .Where(pp => pp.TrainerId == userId)
                .FirstOrDefault();

                //Adds pokemon to TrainerPokedex

                PokedexPokemon p = new PokedexPokemon(TrainerPokedex.Id, addPokemon.Id);
                _db.PokedexPokemon.Add(p);
                _db.SaveChanges();

            }
            return RedirectToPage();
        }

     

    }
}
