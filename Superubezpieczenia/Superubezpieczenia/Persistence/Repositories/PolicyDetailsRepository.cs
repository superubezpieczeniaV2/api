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

            return await _context.PolicyDetails
                .Include(m => m.Model).ThenInclude(m => m.Mark)
                .Include(m => m.MethodUse)
                .Include(m => m.ParkingPlace)
                .Include(m => m.EnginePower)
                .Include(m => m.TypesInsurance)
                .Include(m => m.TypeOwner)
                .Include(m => m.TypeFuel)              
                .ToListAsync();
        }

        public async Task<IEnumerable<PolicyDetails>> FindByUser (string username)
        {
            return await _context.PolicyDetails.Include(m => m.Model).Where(x => x.Username == username).ToListAsync();
        }
        public PolicyDetails FindById(int id)
        {
            return _context.PolicyDetails.FirstOrDefault(x => x.IDPolicyDetails == id);
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
