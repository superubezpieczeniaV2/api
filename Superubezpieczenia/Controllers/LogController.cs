using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Logger;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class LogController : Controller
    {
        public readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<IEnumerable<Log>> All()
        {
            var logs = await _logService.All();
            return logs;
        }

    }
}
