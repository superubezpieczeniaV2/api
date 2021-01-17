using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class TypeInsuranceService : ITypeInsuranceService
    {
        public readonly ITypeInsuranceRepository _typeInsuranceRepository;
        public TypeInsuranceService(ITypeInsuranceRepository typeInsuranceRepository)
        {
            _typeInsuranceRepository = typeInsuranceRepository;
        }

        public void AddTypeInsurance(TypeInsurance typeInsurance)
        {
            _typeInsuranceRepository.AddTypeInsurance(typeInsurance);
        }

        public async Task<IEnumerable<TypeInsurance>> AllTypeInsurance()
        {
            return await _typeInsuranceRepository.AllTypeInsurance();
        }

        public void DeleteTypeInsurance(TypeInsurance typeInsurance)
        {
            _typeInsuranceRepository.DeleteTypeInsurance(typeInsurance);
        }

        public TypeInsurance FindById(int id)
        {
            return _typeInsuranceRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _typeInsuranceRepository.SaveChanges();
        }

        public void UpdateTypeInsurance(TypeInsurance typeInsurance)
        {
            _typeInsuranceRepository.UpdateTypeInsurance(typeInsurance);
        }
    }
}
