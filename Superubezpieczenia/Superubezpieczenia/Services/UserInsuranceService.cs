using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class UserInsuranceService : IUserInsuranceService
    {
        public readonly IUserInsuranceRepository _userInsuranceRepository;
        public UserInsuranceService(IUserInsuranceRepository userInsuranceRepository)
        {
            _userInsuranceRepository = userInsuranceRepository;
        }
        public async Task<IEnumerable<Insurance>> FindUserInsurance(string user)
        {
           return await _userInsuranceRepository.FindUserInsurance(user);
        }
    }
}
