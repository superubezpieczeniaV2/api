using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface IInsuranceService
    {
        Task<IEnumerable<Insurance>> AllInsurance();
        Insurance FindById(int id);
        void AddInsurance(Insurance insurance);
        void DeleteInsurance(Insurance insurance);
        void UpdateInsurance(Insurance insurance);
        bool SaveChanges();
    }
}
