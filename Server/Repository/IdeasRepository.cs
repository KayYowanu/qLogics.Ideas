using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using qLogics.Ideas.Models;

namespace qLogics.Ideas.Repository
{
    public class IdeasRepository : IIdeasRepository, IService
    {
        private readonly IdeasContext _db;

        public IdeasRepository(IdeasContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Ideas> GetIdeass(int ModuleId)
        {
            return _db.Ideas.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Ideas GetIdeas(int IdeasId)
        {
            return _db.Ideas.Find(IdeasId);
        }

        public Models.Ideas AddIdeas(Models.Ideas Ideas)
        {
            _db.Ideas.Add(Ideas);
            _db.SaveChanges();
            return Ideas;
        }

        public Models.Ideas UpdateIdeas(Models.Ideas Ideas)
        {
            _db.Entry(Ideas).State = EntityState.Modified;
            _db.SaveChanges();
            return Ideas;
        }

        public void DeleteIdeas(int IdeasId)
        {
            Models.Ideas Ideas = _db.Ideas.Find(IdeasId);
            _db.Ideas.Remove(Ideas);
            _db.SaveChanges();
        }
    }
}
