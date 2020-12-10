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

        public IActionResult OnPost(PokemonVM testPokemon)
        {

            if(testPokemon?.PokeNumber == null)
            {
                return RedirectToPage("/Catologue");
            }

            int? pokedexId = HttpContext.Session.GetInt32("PokedexId");
            bool isUser = User.Identity.IsAuthenticated;
            string trainerId = null;

            if (isUser) 
            {
                trainerId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            }


            Models.Pokedex pokedex;

            //if (pokedexId == null)
            //{
            //    pokedex = new Models.Pokedex(Int32.Parse(trainerId));
            //    _db.PokeDex.Add(pokedex);
            //    _db.SaveChanges();
            //    pokedexId = pokedex.Id;
            //}
            //else if (pokedexId != null)
            //{
            //    Pokedex = _db.PokeDex
            //    .Include(p => p.PokedexPokemons)
            //    .ThenInclude(pp => pp.Pokemon)
            //    .Where(p => p.Id == (int)HttpContext.Session.GetInt32("Id"))
            //.FirstOrDefault();

            //}

            int PokedexId = Pokedex.Id;
            PokedexPokemon pp;

            pp = _db.PokedexPokemon
                .Where(pp => pp.Pokedex.Id == pokedexId && pp.Pokemon.PokeNumber == testPokemon.PokeNumber).FirstOrDefault();

            

            _db.SaveChanges();

            HttpContext.Session.SetInt32("pokedexId", (int)pokedexId);

            return RedirectToPage();
        }


    }
}
