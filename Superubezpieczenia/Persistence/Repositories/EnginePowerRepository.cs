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
    public class EnginePowerRepository : BaseRepository, IEnginePowerRepository
    {
        public EnginePowerRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddEnginePower(EnginePower enginePower)
        {
            _context.EnginePowers.Add(enginePower);
        }

        public async Task<IEnumerable<EnginePower>> AllEnginePower()
        {
            return await _context.EnginePowers.ToListAsync();
        }

        public void DeleteEnginePower(EnginePower enginePower)
        {
            _context.EnginePowers.Remove(enginePower);
        }

        public EnginePower FindById(int id)
        {
            return _context.EnginePowers.FirstOrDefault(p => p.IDEnginePower == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEnginePower(EnginePower enginePower)
        {
            
        }
    }
}
