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
    public class TypeInsuranceController : ControllerBase
    {
        public readonly ITypeInsuranceService _typeInsuranceService;
        public readonly IMapper _mapper;
        public TypeInsuranceController(ITypeInsuranceService typeInsuranceService, IMapper mapper)
        {
            _typeInsuranceService = typeInsuranceService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<TypeInsurance>> AllTypeInsurance()
        {
            var typeInsurance = await _typeInsuranceService.AllTypeInsurance();
            return typeInsurance;
        }
        [HttpPost]
        public ActionResult<TypeInsuranceVM> AddTypeInsurance(TypeInsuranceDTO typeInsuranceDTO)
        {
            var typeInsurance = _mapper.Map<TypeInsurance>(typeInsuranceDTO);
            _typeInsuranceService.AddTypeInsurance(typeInsurance);
            _typeInsuranceService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTypeInsurance(int id)
        {
            var dTypeInsurance = _typeInsuranceService.FindById(id);
            if (dTypeInsurance == null)
            {
                return NotFound();
            }
            _typeInsuranceService.DeleteTypeInsurance(dTypeInsurance);
            _typeInsuranceService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTypeInsurance(TypeInsuranceDTO typeInsuranceDTO, int id)
        {
            var uTypeInsurance = _typeInsuranceService.FindById(id);
            if (uTypeInsurance == null)
            {
                return NotFound();
            }
            _mapper.Map(typeInsuranceDTO, uTypeInsurance);
            _typeInsuranceService.UpdateTypeInsurance(uTypeInsurance);
            _typeInsuranceService.SaveChanges();

            return Ok();
        }
    }
}
