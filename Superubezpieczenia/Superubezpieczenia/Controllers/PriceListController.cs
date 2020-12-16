using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        public readonly IPriceListService _priceListService;
        public readonly IMapper _mapper;
        public PriceListController(IPriceListService priceListService, IMapper mapper)
        {
            _priceListService = priceListService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PriceList>> AllPriceList()
        {
            var priceList = await _priceListService.AllPriceList();
            return priceList;
        }
        [HttpPost]
        public ActionResult<PriceListVM> AddPriceList(PriceListDTO priceListDTO)
        {
            var priceList = _mapper.Map<PriceList>(priceListDTO);
            _priceListService.AddPriceList(priceList);
            _priceListService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePriceList(int id)
        {
            var dPriceList = _priceListService.FindById(id);
            if (dPriceList == null)
            {
                return NotFound();
            }
            _priceListService.DeletePriceList(dPriceList);
            _priceListService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePriceList(PriceListDTO priceListDTO, int id)
        {
            var uPriceList = _priceListService.FindById(id);
            if (uPriceList == null)
            {
                return NotFound();
            }
            _mapper.Map(priceListDTO, uPriceList);
            _priceListService.UpdatePriceList(uPriceList);
            _priceListService.SaveChanges();

            return Ok();
        }
    }
}
