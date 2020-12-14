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
        const int ITEMS_PER_PAGE = 6;

        private readonly IPokemonVMService _IpokemonVMService;
        public CatalogueModel(IPokemonVMService ipokemonVMService)
        {
            _IpokemonVMService = ipokemonVMService;
        }
       
        public PokemonIndexVM PokemonIndex = new PokemonIndexVM();

        public async Task OnGet(PokemonIndexVM pokemonIndex, int? pageIndex)
        {
            PokemonIndex = _IpokemonVMService.GetPokemonsVM(pageIndex ?? 0, ITEMS_PER_PAGE, pokemonIndex.TypesFilterApplied);

        }
    }
}
