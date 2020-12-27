using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : Controller
    {
        public readonly IInsuranceService _insuranceService;
        public readonly IMapper _mapper;

        public InsuranceController(IInsuranceService insuranceService, IMapper mapper)
        {
            _insuranceService = insuranceService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Insurance>> AllEnginePower()
        {
            var insurance = await _insuranceService.AllInsurance();
            return insurance;

        }
        [HttpPost]
        public ActionResult<InsuranceVM> AddEnginePower(InsuranceDTO insuranceDTO)
        {
            var insurance = _mapper.Map<Insurance>(insuranceDTO);
            _insuranceService.AddInsurance(insurance);
            _insuranceService.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteInsurance(int id)
        {
            var dInsurance = _insuranceService.FindById(id);
            if (dInsurance == null)
            {
                return NotFound();
            }
            _insuranceService.DeleteInsurance(dInsurance);
            _insuranceService.SaveChanges();
            return Ok();

        }
        [HttpPut("{id}")]
        public ActionResult UpdateInsurance(InsuranceDTO insuranceDTO, int id)
        {
            var uInsurance = _insuranceService.FindById(id);
            if (uInsurance == null)
            {
                return NotFound();
            }
            _mapper.Map(insuranceDTO, uInsurance);
            _insuranceService.UpdateInsurance(uInsurance);
            _insuranceService.SaveChanges();

            return Ok();
        }


    }
}
