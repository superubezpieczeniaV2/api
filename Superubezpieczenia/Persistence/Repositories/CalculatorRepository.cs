using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class CalculatorRepository : BaseRepository, ICalculatorRepository
    {
        private  double insurancePrice = 0;
        
        public CalculatorRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public double InsurancePrice(CalculatorDTO dto)
        {
            var value = _context.EnginePowers.FirstOrDefault(x => x.IDEnginePower == dto.IDEnginePower);
            insurancePrice += value.Value;

            var value1 = _context.Marks.FirstOrDefault(x => x.IDMark == dto.IDMark);
            insurancePrice += value1.Value;

            var value2 = _context.MethodUses.FirstOrDefault(x => x.IDMethodUse == dto.IDMethodUse);
            insurancePrice += value2.Value;

            var value3 = _context.Models.FirstOrDefault(x => x.IDModel == dto.IDModel);
            insurancePrice += value3.Value;

            var value4 = _context.ParkingPlaces.FirstOrDefault(x => x.IDParkingPlace == dto.IDParkingPlace);
            insurancePrice += value4.Value;

            var value5 = _context.TypeInsurance.FirstOrDefault(x => x.IDTypeInsurance == dto.IDTypeInsurance);
            insurancePrice += value5.Price;

            var value6 = _context.TypeOwners.FirstOrDefault(x => x.IDTypeOwner == dto.IDTypeOwner);
            insurancePrice += value6.Value;

            return insurancePrice;
        }



        
    }
}
