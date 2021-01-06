using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolicyDetailsController : ControllerBase
    {
        public readonly IPolicyDetailsService _policyDetailsService;
        public readonly IMapper _mapper;
        public readonly ILog _log;

        public PolicyDetailsController(IPolicyDetailsService policyDetailsService, IMapper mapper, ILog log)
        {
            _policyDetailsService = policyDetailsService;
            _mapper = mapper;
            _log = log;

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
            var user = User.Identity.Name;
            policyDetails.Username = user;
            _policyDetailsService.AddPolicyDetails(policyDetails);
            _policyDetailsService.SaveChanges();
            _log.Save(user, "Dodano szczegóły polisy", GetType().Name);
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
            _log.Save(User.Identity.Name, "Usunięto szczegóły polisy", GetType().Name);
            return Ok();

        }
        
    }
}
