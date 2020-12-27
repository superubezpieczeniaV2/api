using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class InsuranceService : IInsuranceService
    {
        public readonly IInsuranceRepository _insuranceRepository;
        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;

        }

        public void AddInsurance(Insurance insurance)
        {
            _insuranceRepository.AddInsurance(insurance);
        }

        public async Task<IEnumerable<Insurance>> AllInsurance()
        {
            return await _insuranceRepository.AllInsurance();
        }

        public void DeleteInsurance(Insurance insurance)
        {
            _insuranceRepository.DeleteInsurance(insurance);
        }

        public Insurance FindById(int id)
        {
            return _insuranceRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _insuranceRepository.SaveChanges();
        }

        public void UpdateInsurance(Insurance insurance)
        {
            _insuranceRepository.UpdateInsurance(insurance);
        }
    }
}
