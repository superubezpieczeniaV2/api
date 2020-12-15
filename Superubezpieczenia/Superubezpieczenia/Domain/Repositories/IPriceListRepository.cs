using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IPriceListRepository
    {
        Task<IEnumerable<PriceList>> AllPriceList();
        PriceList FindById(int id);
        void AddPriceList(PriceList priceList);
        void DeletePriceList(PriceList priceList);
        void UpdatePriceList(PriceList priceList);
        bool SaveChanges();
    }
}
