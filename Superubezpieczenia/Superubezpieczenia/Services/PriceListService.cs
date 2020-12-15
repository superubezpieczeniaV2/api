using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class PriceListService : IPriceListService
    {
        public readonly IPriceListRepository _priceListRepository;
        public PriceListService(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        public void AddPriceList(PriceList priceList)
        {
            _priceListRepository.AddPriceList(priceList);
        }

        public async Task<IEnumerable<PriceList>> AllPriceList()
        {
            return await _priceListRepository.AllPriceList();
        }

        public void DeletePriceList(PriceList priceList)
        {
            _priceListRepository.DeletePriceList(priceList);
        }

        public PriceList FindById(int id)
        {
            return _priceListRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _priceListRepository.SaveChanges();
        }

        public void UpdatePriceList(PriceList priceList)
        {
            _priceListRepository.UpdatePriceList(priceList);
        }
    }
}
