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
    public class PriceListRepository : BaseRepository, IPriceListRepository
    {
        public PriceListRepository(ApplicationDbContext context) : base(context)
        {
                
        }
        public void AddPriceList(PriceList priceList)
        {
            _context.PriceLists.Add(priceList);
        }

        public async Task<IEnumerable<PriceList>> AllPriceList()
        {
            return await _context.PriceLists.ToListAsync();
        }

        public void DeletePriceList(PriceList priceList)
        {
            _context.PriceLists.Remove(priceList);
        }

        public PriceList FindById(int id)
        {
            return _context.PriceLists.FirstOrDefault(p => p.IDPriceList == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePriceList(PriceList priceList)
        {
            
        }
    }
}
