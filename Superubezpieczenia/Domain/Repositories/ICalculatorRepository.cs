using Superubezpieczenia.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface ICalculatorRepository
    {
        public double InsurancePrice(CalculatorDTO calculatorDTO);

    }
}
