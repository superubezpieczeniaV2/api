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
    public class TypeFuelController : ControllerBase
    {
        public readonly ITypeFuelService _typeFuelService;
        public readonly IMapper _mapper;

        public TypeFuelController(ITypeFuelService typeFuelService, IMapper mapper)
        {
            _typeFuelService = typeFuelService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<TypeFuel>> AllTypeFuel()
        {
            var typeFuel = await _typeFuelService.AllTypeFuel();
            return typeFuel;
        }
        [HttpPost]
        public ActionResult<TypeFuelDTO> AddTypeFuel(TypeFuelDTO typeFuelDTO)
        {
            var typeFuel = _mapper.Map<TypeFuel>(typeFuelDTO);
            _typeFuelService.AddTypeFuel(typeFuel);
            _typeFuelService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTypeFuel(int id)
        {
            var dTypeFuel = _typeFuelService.FindById(id);
            if (dTypeFuel == null)
            {
                return NotFound();
            }
            _typeFuelService.DeleteTypeFuel(dTypeFuel);
            _typeFuelService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTypeFuel(TypeFuelDTO typeFuelDTO, int id)
        {
            var uTypeFuel = _typeFuelService.FindById(id);
            if (uTypeFuel == null)
            {
                return NotFound();
            }
            _mapper.Map(typeFuelDTO, uTypeFuel);
            _typeFuelService.UpdateTypeFuel(uTypeFuel);
            _typeFuelService.SaveChanges();

            return Ok();
        }
    }
}
