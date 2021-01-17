using Superubezpieczenia.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface ICalculatorService
    {
        public double InsurancePrice(CalculatorDTO calculatorDTO);
    }
}
