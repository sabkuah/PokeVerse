using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeVerse.Interfaces;
using PokeVerse.Models;

namespace PokeVerse.Data.Migrations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PokeVerseDbContext _db;

        public BaseRepository(PokeVerseDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }
    }
}
