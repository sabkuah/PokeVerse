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
using PokeVerse.Services;
using PokeVerse.ViewModels;

namespace PokeVerse.Pages
{
    public class CatalogueModel : PageModel
    {
        private readonly IPokemonVMService _IpokemonVMService;
        public CatalogueModel(IPokemonVMService ipokemonVMService)
        {
            _IpokemonVMService = ipokemonVMService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int Count { get; set; } = 150;
        public int PageSize { get; set; } = 6;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public PokemonIndexVM PokemonIndex = new PokemonIndexVM();

        public async Task OnGet(PokemonIndexVM pokemonIndex)
        {
            PokemonIndex = _IpokemonVMService.GetPokemonsVM(pokemonIndex.TypesFilterApplied, CurrentPage, PageSize);

        }
    }
}
