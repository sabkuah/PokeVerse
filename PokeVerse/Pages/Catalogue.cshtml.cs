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
using PokeVerse.Services;
using PokeVerse.ViewModels;

namespace PokeVerse.Pages
{
    public class CatalogueModel : PageModel
    {
        const int ITEMS_PER_PAGE = 6;

        private readonly IPokemonVMService _IpokemonVMService;
        public CatalogueModel(IPokemonVMService ipokemonVMService)
        {
            _IpokemonVMService = ipokemonVMService;
        }
       
        public PokemonIndexVM PokemonIndex = new PokemonIndexVM();

        public async Task OnGet(PokemonIndexVM pokemonIndex, int? pageIndex)

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
            PokemonIndex = _IpokemonVMService.GetPokemonsVM(pageIndex ?? 0, ITEMS_PER_PAGE, pokemonIndex.TypesFilterApplied);

            string userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;


            TrainerPokedex = _db.PokeDex
                .Include(pp => pp.PokedexPokemons)
                .ThenInclude(p => p.Pokemon)
                .Where(pp => pp.TrainerId == userId)
            .FirstOrDefault();

        }

    }
}
