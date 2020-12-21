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
        Task<IEnumerable<PolicyDetails>> FindByUser(string id);
        void AddPolicyDetails(PolicyDetails policy);
        bool SaveChanges();
        void DeletePolicyDetails(PolicyDetails policy);
    }
}
