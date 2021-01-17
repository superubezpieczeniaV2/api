using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IUserInsuranceRepository
    {
        Task<IEnumerable<Insurance>> FindUserInsurance(string user);
    }
}
