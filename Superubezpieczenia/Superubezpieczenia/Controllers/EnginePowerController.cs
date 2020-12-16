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
    public class EnginePowerController : ControllerBase
    {
        public readonly IEnginePowerService _enginePowerService;
        public readonly IMapper _mapper;

        public EnginePowerController(IEnginePowerService enginePowerService, IMapper mapper)
        {
            _enginePowerService = enginePowerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EnginePower>> AllEnginePower()
        {
            var enginepower = await _enginePowerService.AllEnginePower();
            return enginepower;

        }
        [HttpPost]
        public ActionResult<EnginePowerVM> AddEnginePower(EnginePowerDTO enginepowerDTO)
        {
            var enginepower = _mapper.Map<EnginePower>(enginepowerDTO);
            _enginePowerService.AddEnginePower(enginepower);
            _enginePowerService.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEnginePower(int id)
        {
            var dEnginePower = _enginePowerService.FindById(id);
            if (dEnginePower==null)
            {
                return NotFound();
            }
            _enginePowerService.DeleteEnginePower(dEnginePower);
            _enginePowerService.SaveChanges();
            return Ok();

        }
        [HttpPut("{id}")]
        public ActionResult UpdateEnginePower(EnginePowerDTO enginepowerDTO, int id)
        {
            var uEnginePower = _enginePowerService.FindById(id);
            if (uEnginePower == null)
            {
                return NotFound();
            }
            _mapper.Map(enginepowerDTO, uEnginePower);
            _enginePowerService.UpdateEnginePower(uEnginePower);
            _enginePowerService.SaveChanges();

            return Ok();
        }
    }
}
