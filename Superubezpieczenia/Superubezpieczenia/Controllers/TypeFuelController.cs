using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
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
        public readonly ILogService _log;

        public TypeFuelController(ITypeFuelService typeFuelService, IMapper mapper, ILogService log)
        {
            _typeFuelService = typeFuelService;
            _mapper = mapper;
            _log = log;
        }
        [HttpGet]
        
        public async Task<IEnumerable<TypeFuel>> AllTypeFuel()
        {
            var typeFuel = await _typeFuelService.AllTypeFuel();
            return typeFuel;
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<TypeFuelDTO> AddTypeFuel(TypeFuelDTO typeFuelDTO)
        {
            var typeFuel = _mapper.Map<TypeFuel>(typeFuelDTO);
            _typeFuelService.AddTypeFuel(typeFuel);
            _typeFuelService.SaveChanges();
            _log.Save(User.Identity.Name, "Dodano rodzaj paliwa", GetType().Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteTypeFuel(int id)
        {
            var dTypeFuel = _typeFuelService.FindById(id);
            if (dTypeFuel == null)
            {
                return NotFound();
            }
            _typeFuelService.DeleteTypeFuel(dTypeFuel);
            _typeFuelService.SaveChanges();
            _log.Save(User.Identity.Name, "Usunięto rodzaj paliwa", GetType().Name);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
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
            _log.Save(User.Identity.Name, "Edytowano rodzaj paliwa", GetType().Name);
            return Ok();
        }
    }
}
