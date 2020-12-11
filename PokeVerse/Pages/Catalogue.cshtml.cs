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
using PokeVerse.Interfaces;
using PokeVerse.Models;
using PokeVerse.ViewModels;

namespace PokeVerse.Pages
{
    public class CatalogueModel : PageModel
    {
        private readonly IPokemonVMService _pokemonVMService;
        private readonly PokeVerseDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public Models.Pokedex TrainerPokedex { get; set; }


        public CatalogueModel(IPokemonVMService pokemonVMService, PokeVerseDbContext db, UserManager<IdentityUser> userManager)
        {
            _pokemonVMService = pokemonVMService;
            _db = db;
            _userManager = userManager;
        }

        public PokemonIndexVM PokemonIndex = new PokemonIndexVM();


        public async Task OnGet(PokemonIndexVM pokemonIndex)
        {
            PokemonIndex = _pokemonVMService.GetPokemonsVM(pokemonIndex.TypesFilterApplied);

            string userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;


            TrainerPokedex = _db.PokeDex
                .Include(pp => pp.PokedexPokemons)
                .ThenInclude(p => p.Pokemon)
                .Where(pp => pp.TrainerId == userId)
            .FirstOrDefault();

        }

    }
}
