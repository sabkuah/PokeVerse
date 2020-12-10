//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using PokeVerse.Interfaces;
//using PokeVerse.Models;
//using PokeVerse.ViewModels;

//namespace PokeVerse.Services
//{
//    public class PokemonVMService: IPokemonVMService
//    {
//        private readonly IBaseRepository<Pokemon> _pokemonRepo;
//        private readonly IBaseRepository<PokemonType> _typeRepo;

//        public PokemonVMService(IBaseRepository<Pokemon> productRepo, IBaseRepository<PokemonType> typeRepo)
//        {
//            _pokemonRepo = productRepo;
//            _typeRepo = typeRepo;
//        }

//        public PokemonIndexVM GetPokemonsVM(int? typeId)
//        {
//            IQueryable<Pokemon> pokemons = _pokemonRepo.GetAll();
//            if (typeId != null)
//                pokemons = pokemons.Where(p => p.PokemonTypes == typeId);

//            var vm = new PokemonIndexVM()
//            {

//                Pokemons = pokemons.Select(p => new PokemonVM
//                {
//                    PokeNumber = p.PokeNumber,
//                    Name = p.Name,
//                    Type0 = p.Type0,
//                    Type1 = p.Type1,
//                    Attack = p.Attack,
//                    Defense = p.Defense,
//                    Speed = p.Speed,
//                }).ToList(),
//                Types = GetTypes().ToList()
//            };
//            return vm;
//        }
//        public IEnumerable<SelectListItem> GetTypes()
//        {
//            var types = _typeRepo.GetAll().Select(t => new SelectListItem()
//            {
//                Value = t.Id.ToString(),
//                Text = t.Type
//            }).OrderBy(t => t.Text).ToList();

//            var allItem = new SelectListItem()
//            {
//                Value = null,
//                Text = "All",
//                Selected = true
//            };
//            types.Insert(0, allItem);

//            return types;
//        }
//    }
//}
