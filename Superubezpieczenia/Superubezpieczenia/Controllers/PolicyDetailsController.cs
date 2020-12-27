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
    public class PolicyDetailsController : ControllerBase
    {
        public readonly IPolicyDetailsService _policyDetailsService;
        public readonly IMapper _mapper;

        public PolicyDetailsController(IPolicyDetailsService policyDetailsService, IMapper mapper)
        {
            _policyDetailsService = policyDetailsService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PolicyDetails>> AllPolicys()
        {
            var policyDetails = await _policyDetailsService.AllPolicys();
            return policyDetails;

        }
        [HttpPost]
        public ActionResult<PolicyDetailsVM> AddPolicyDetails(PolicyDetailsDTO policyDetailsDTO)
        {
            var policyDetails = _mapper.Map<PolicyDetails>(policyDetailsDTO);
            _policyDetailsService.AddPolicyDetails(policyDetails);
            _policyDetailsService.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePolicyDetails(int id)
        {
            var policyDetails = _policyDetailsService.FindById(id);
            if (policyDetails == null)
            {
                return NotFound();
            }
            _policyDetailsService.DeletePolicyDetails(policyDetails);
            _policyDetailsService.SaveChanges();
            return Ok();

        }
        
    }
}
