using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.MailSender;
using Superubezpieczenia.MailSender.Models;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserInsuranceController : ControllerBase
    {
        public readonly IUserInsuranceService _userInsuranceService;
        
        public UserInsuranceController(IUserInsuranceService userInsuranceService, IMailService mailService)
        {
            _userInsuranceService = userInsuranceService;
            

        }
        [HttpGet]
        public async Task<IEnumerable<Insurance>> FindUserInsurance(string user)
        {
            var userInsurance = await _userInsuranceService.FindUserInsurance(user);
            return userInsurance;


        }
    }
}
