using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class CalculatorService : ICalculatorService
    {
        public readonly ICalculatorRepository _calculatorRepository;
        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public double InsurancePrice(CalculatorDTO callculatorDTO )
        {
            return _calculatorRepository.InsurancePrice(callculatorDTO);
        }
    }
}
