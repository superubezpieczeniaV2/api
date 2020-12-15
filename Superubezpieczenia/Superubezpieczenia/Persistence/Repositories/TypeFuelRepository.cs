using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class TypeFuelRepository : BaseRepository, ITypeFuelRepository
    {
        public TypeFuelRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddTypeFuel(TypeFuel typeFuel)
        {
            _context.TypeFuels.Add(typeFuel);
        }

        public async Task<IEnumerable<TypeFuel>> AllTypeFuel()
        {
            return await _context.TypeFuels.ToListAsync();
        }      

        public void DeleteTypeFuel(TypeFuel typeFuel)
        {
            _context.TypeFuels.Remove(typeFuel);
        }

        public TypeFuel FindById(int id)
        {
            return _context.TypeFuels.FirstOrDefault(p => p.IDTypeFuel == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTypeFuel(TypeFuel typeFuel)
        {
            
        }
    }
}
