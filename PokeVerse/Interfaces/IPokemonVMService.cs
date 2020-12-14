using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PokeVerse.Models;
using PokeVerse.ViewModels;

namespace PokeVerse.Interfaces
{
    public interface IPokemonVMService
    {
        PokemonIndexVM GetPokemonsVM(int pageIndex, int itemsPerPage, string typeName);
        IEnumerable<SelectListItem> GetTypes();
    }
}
