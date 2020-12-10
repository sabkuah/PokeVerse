using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeVerse.Models;

namespace PokeVerse.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
    }
}
