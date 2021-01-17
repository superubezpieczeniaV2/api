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
    public class TypeOwnerRepository : BaseRepository, ITypeOwnerRepository
    {
        public TypeOwnerRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddTypeOwner(TypeOwner typeOwner)
        {
            _context.TypeOwners.Add(typeOwner);
        }

        public async Task<IEnumerable<TypeOwner>> AllTypeOwner()
        {
            return await _context.TypeOwners.ToListAsync();
        }

        public void DeleteTypeOwner(TypeOwner typeOwner)
        {
            _context.TypeOwners.Remove(typeOwner);
        }

        public TypeOwner FindById(int id)
        {
           return _context.TypeOwners.FirstOrDefault(p => p.IDTypeOwner == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTypeOwner(TypeOwner typeOwner)
        {
            
        }
    }
}
