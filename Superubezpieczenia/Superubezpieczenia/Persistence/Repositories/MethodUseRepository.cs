using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class MethodUseRepository : BaseRepository, IMethodUseRepository
    {
        public MethodUseRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddMethodUse(MethodUse methodUse)
        {
            _context.MethodUses.Add(methodUse);
        }

        public async Task<IEnumerable<MethodUse>> AllMethodUse()
        {
            return await _context.MethodUses.ToListAsync();
        }

        public void DeleteMethodUse(MethodUse methodUse)
        {
            _context.MethodUses.Remove(methodUse);
        }

        public MethodUse FindById(int id)
        {
            return _context.MethodUses.FirstOrDefault(p => p.IDMethodUse == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMethodUse(MethodUse methodUse)
        {
            
        }
    }
}
