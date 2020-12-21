using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class PolicyDetailsRepository : BaseRepository, IPolicyDetailsRepository
    {
        public PolicyDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddPolicyDetails(PolicyDetails policyDetails)
        {
            _context.PolicyDetails.Add(policyDetails);
        }


        public async Task<IEnumerable<PolicyDetails>> AllPolicys()
        {

            return await _context.PolicyDetails.ToListAsync();
        }

        public async Task<IEnumerable<PolicyDetails>> FindByUser (string id)
        {
            return await _context.PolicyDetails.Include(x => x.User).Where(x => x.IDUser == id).ToListAsync();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void DeletePolicyDetails(PolicyDetails policy)
        {
            _context.PolicyDetails.Remove(policy);
        }
    }
}
