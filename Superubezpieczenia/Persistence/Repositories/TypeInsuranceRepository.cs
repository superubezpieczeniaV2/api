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
    public class TypeInsuranceRepository : BaseRepository, ITypeInsuranceRepository
    {
        public TypeInsuranceRepository(ApplicationDbContext context) : base(context)
        {
                
        }
        public void AddTypeInsurance(TypeInsurance typeInsurance)
        {
            _context.TypeInsurance.Add(typeInsurance);
        }

        public async Task<IEnumerable<TypeInsurance>> AllTypeInsurance()
        {
            return await _context.TypeInsurance.ToListAsync();
        }

        public void DeleteTypeInsurance(TypeInsurance priceList)
        {
            _context.TypeInsurance.Remove(priceList);
        }

        public TypeInsurance FindById(int id)
        {
            return _context.TypeInsurance.FirstOrDefault(p => p.IDTypeInsurance == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTypeInsurance(TypeInsurance priceList)
        {
            
        }
    }
}
