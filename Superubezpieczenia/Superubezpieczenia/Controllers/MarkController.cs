using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    public class MarkController : Controller
    {
        public readonly IMarkService _markService;

        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }
        [HttpGet]
        public async Task<IEnumerable<Mark>> AllMarks()
        {
            var mark = await _markService.AllMarks();
            return mark;
        }
    }
}
