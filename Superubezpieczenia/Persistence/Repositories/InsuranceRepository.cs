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
    public class InsuranceRepository : BaseRepository, IInsuranceRepository
    {
        public InsuranceRepository(ApplicationDbContext context): base(context)
        {

        }

        public void AddInsurance(Insurance insurance)
        {
            _context.Insurances.Add(insurance);
        }

        public async Task<IEnumerable<Insurance>> AllInsurance()
        {
            return await _context.Insurances.ToListAsync();
        }

        public void DeleteInsurance(Insurance insurance)
        {
            _context.Insurances.Remove(insurance);
        }

        public Insurance FindById(int id)
        {
            return _context.Insurances.FirstOrDefault(x => x.IDInsurance == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInsurance(Insurance insurance)
        {
            
        }
    }
}
