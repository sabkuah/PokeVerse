using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokeVerse.Interfaces;
using PokeVerse.Models;
using PokeVerse.ViewModels;

namespace PokeVerse.Pages
{
    public class CatalogueModel : PageModel
    {
        private readonly IPokemonVMService _pokemonVMService;

        public CatalogueModel(IPokemonVMService pokemonVMService)
        {
            _pokemonVMService = pokemonVMService;
        }

        //private readonly PokeVerse.Data.PokeVerseDbContext _context;

        //public _CatalogueModel(PokeVerse.Data.PokeVerseDbContext context)
        //{
        //    _context = context;
        //}

        public PokemonIndexVM PokemonIndex = new PokemonIndexVM();

        //public List<PokemonVM> PokemonVM = new List<PokemonVM>();

        public async Task OnGet(PokemonIndexVM pokemonIndex)
        {
            PokemonIndex = _pokemonVMService.GetPokemonsVM(pokemonIndex.TypesFilterApplied);

        }

        //public async Task OnGetAsync()
        //{
        //    PokemonVM = await _context.Pokemon.Select(p => new PokemonVM
        //    {
        //        PokeNumber = p.PokeNumber,
        //        Name = p.Name,
        //        Type0 = p.Type0,
        //        Type1 = p.Type1,
        //        Attack = p.Attack,
        //        Defense = p.Defense,
        //        Speed = p.Speed,
        //    }).ToListAsync();
        //}
    }
}
