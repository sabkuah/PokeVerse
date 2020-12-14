using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PokeVerse.Interfaces;
using PokeVerse.Models;
using PokeVerse.ViewModels;

namespace PokeVerse.Services
{
    public class PokemonVMService : IPokemonVMService
    {
        private readonly IBaseRepository<Pokemon> _pokemonRepo;
        private readonly IBaseRepository<Models.Type> _typeRepo;    
        public PokemonVMService(IBaseRepository<Pokemon> productRepo, IBaseRepository<Models.Type> typeRepo)
        {
            _pokemonRepo = productRepo;
            _typeRepo = typeRepo;
        }
      
        public PokemonIndexVM GetPokemonsVM(int pageIndex, int itemsPerPage, string typeName)
        {
            IQueryable<Pokemon> pokemons = _pokemonRepo.GetAll().OrderBy(Pokemon => Pokemon.PokeNumber);
            if (typeName != null && typeName != "NULL")
                pokemons = pokemons.Where(p => p.Type0 == typeName || p.Type1 == typeName);

            int totalItems = pokemons.Count();
            pokemons = pokemons.Skip(pageIndex * itemsPerPage).Take(itemsPerPage);

            var vm = new PokemonIndexVM()
            {

                Pokemons = pokemons.Select(p => new PokemonVM
                {
                    PokeNumber = p.PokeNumber,
                    Name = p.Name,
                    Type0 = p.Type0,
                    Type1 = p.Type1,
                    Attack = p.Attack,
                    Defense = p.Defense,
                    Speed = p.Speed,
                }).ToList(),
                Types = GetTypes().ToList(),

                PaginationInfo = new PaginationInfoVM()
                {
                    PageIndex = pageIndex,
                    ItemsPerPage = pokemons.Count(),
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPerPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.PageIndex == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.PageIndex == 0) ? "is-disabled" : "";
            return vm;
        }

        public IEnumerable<SelectListItem> GetTypes()
        {
            var types = _typeRepo.GetAll().Select(t => new SelectListItem()
            {
                Value = t.Name.ToString(),
                Text = t.Name,
            }).OrderBy(t => t.Text).ToList();

            var allItem = new SelectListItem()
            {
                Value = "NULL",
                Text = "All",
                Selected = true
            };
            types.Insert(0, allItem);

            return types.ToList();
        }
    }
}
