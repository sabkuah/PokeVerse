using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokeVerse.Models;

namespace PokeVerse.Pages.Pokedex
{
    public class _PokedexPartialModel : PageModel
    {
        private readonly PokeVerse.Data.PokeVerseDbContext _db;

        public _PokedexPartialModel(PokeVerse.Data.PokeVerseDbContext db)
        {
            _db = db;
        }

        public IList<PokedexPokemon> PokedexPokemons { get; set; }

        public async Task OnGetAsync()
        {
            PokedexPokemons = await _db.PokedexPokemon
                .Include(p => p.Pokedex)
                .Include(p => p.Pokemon).ToListAsync();


        }
    }
}
