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
    public class EnginePowerController : ControllerBase
    {
        public readonly IEnginePowerService _enginePowerService;
        public readonly IMapper _mapper;
        public readonly ILogService _log;
        public EnginePowerController(IEnginePowerService enginePowerService, IMapper mapper, ILogService log)
        {
            _enginePowerService = enginePowerService;
            _mapper = mapper;
            _log = log;
        }
        [HttpGet]
        public async Task<IEnumerable<EnginePower>> AllEnginePower()
        {
            var enginepower = await _enginePowerService.AllEnginePower();
            return enginepower;

        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<EnginePowerVM> AddEnginePower([FromBody] EnginePowerDTO enginepowerDTO)
        {
            var enginepower = _mapper.Map<EnginePower>(enginepowerDTO);
            _enginePowerService.AddEnginePower(enginepower);
            _enginePowerService.SaveChanges();
            _log.Save(User.Identity.Name, "Dodano rodzaj paliwa", GetType().Name);

            return Ok();

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteEnginePower(int id)
        {
            var dEnginePower = _enginePowerService.FindById(id);
            if (dEnginePower==null)
            {
                return NotFound();
            }
            _enginePowerService.DeleteEnginePower(dEnginePower);
            _enginePowerService.SaveChanges();
            _log.Save(User.Identity.Name, "Usunięto rodzaj paliwa", GetType().Name);
            return Ok();

        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateEnginePower([FromBody] EnginePowerDTO enginepowerDTO, int id)
        {
            var uEnginePower = _enginePowerService.FindById(id);
            if (uEnginePower == null)
            {
                return NotFound();
            }
            _mapper.Map(enginepowerDTO, uEnginePower);
            _enginePowerService.UpdateEnginePower(uEnginePower);
            _enginePowerService.SaveChanges();
            _log.Save(User.Identity.Name, "Edytowano rodzaj paliwa", GetType().Name);
            return Ok();
        }
    }
}
