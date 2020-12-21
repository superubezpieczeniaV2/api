using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class PolicyDetailsService : IPolicyDetailsService
    {
        private readonly IPolicyDetailsRepository _policyDetailsRepository;
        public PolicyDetailsService(IPolicyDetailsRepository policyDetailsRepository)
        {
            _policyDetailsRepository = policyDetailsRepository;
        }

        public void AddPolicyDetails(PolicyDetails policyDetails)
        {
            _policyDetailsRepository.AddPolicyDetails(policyDetails);
        }

        public async Task<IEnumerable<PolicyDetails>> AllPolicys()
        {
            return await _policyDetailsRepository.AllPolicys();
        }

        public async Task<IEnumerable<PolicyDetails>> FindByUser(string id)
        {
            return await _policyDetailsRepository.FindByUser(id);
        }

        public bool SaveChanges()
        {
            return _policyDetailsRepository.SaveChanges();
        }
        public void DeletePolicyDetails(PolicyDetails policy)
        {
            _policyDetailsRepository.DeletePolicyDetails(policy);
        }

    }
}
