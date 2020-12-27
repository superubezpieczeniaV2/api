using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Persistence.Repositories;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CalculatorController : Controller
    {
        public readonly ICalculatorService  _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        [HttpPost]
        public  ActionResult InsurancePrice(CalculatorDTO calculatorDTO)
        {

            double result = _calculatorService.InsurancePrice(calculatorDTO);

            return Ok(result);
        }
    }
}
