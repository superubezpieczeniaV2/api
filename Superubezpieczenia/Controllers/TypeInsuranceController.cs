
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
    
    public class TypeInsuranceController : ControllerBase
    {
        public readonly ITypeInsuranceService _typeInsuranceService;
        public readonly IMapper _mapper;
        public readonly ILogService _log;
        public TypeInsuranceController(ITypeInsuranceService typeInsuranceService, IMapper mapper, ILogService log)
        {
            _typeInsuranceService = typeInsuranceService;
            _mapper = mapper;
            _log = log;
        }
        [HttpGet]
        public async Task<IEnumerable<TypeInsurance>> AllTypeInsurance()
        {
            var typeInsurance = await _typeInsuranceService.AllTypeInsurance();
            return typeInsurance;
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<TypeInsuranceVM> AddTypeInsurance([FromBody] TypeInsuranceDTO typeInsuranceDTO)
        {
            var typeInsurance = _mapper.Map<TypeInsurance>(typeInsuranceDTO);
            _typeInsuranceService.AddTypeInsurance(typeInsurance);
            _typeInsuranceService.SaveChanges();
           _log.Save(User?.Identity.Name, "Dodano rodzaj ubezpieczenia", GetType().Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteTypeInsurance(int id)
        {
            var dTypeInsurance = _typeInsuranceService.FindById(id);
            if (dTypeInsurance == null)
            {
                return NotFound();
            }
            _typeInsuranceService.DeleteTypeInsurance(dTypeInsurance);
            _typeInsuranceService.SaveChanges();
            _log.Save(User.Identity.Name, "Usunięto rodzaj ubezpieczenia", GetType().Name);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateTypeInsurance([FromBody] TypeInsuranceDTO typeInsuranceDTO, int id)
        {
            var uTypeInsurance = _typeInsuranceService.FindById(id);
            if (uTypeInsurance == null)
            {
                return NotFound();
            }
            _mapper.Map(typeInsuranceDTO, uTypeInsurance);
            _typeInsuranceService.UpdateTypeInsurance(uTypeInsurance);
            _typeInsuranceService.SaveChanges();
            _log.Save(User.Identity.Name, "Edytowano rodzaj ubezpieczenia", GetType().Name);
            return Ok();
        }
    }
}
