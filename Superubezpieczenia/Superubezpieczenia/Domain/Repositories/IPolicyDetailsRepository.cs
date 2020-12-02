using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IPolicyDetailsRepository
    {
        Task<IEnumerable<PolicyDetails>> AllPolicys();
        void AddPolicyDetails(PolicyDetails policy);
        bool SaveChanges();
    }
}
