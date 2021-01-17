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
    public class UserInsuranceRepository : BaseRepository, IUserInsuranceRepository
    {
        public UserInsuranceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public  async Task<IEnumerable<Insurance>> FindUserInsurance(string user)
        {
            var username = _context.Users.FirstOrDefault(x => x.UserName == user);
            var userId = _context.Users.FirstOrDefault(x => x.Id == user);
            if (username != null)
            {               
                
                return await  _context.Insurances.Where(x => x.Id == username.UserName).ToListAsync();
            }
            if(userId != null)
            {
                return await  _context.Insurances.Where(r => r.Id == userId.Id).ToListAsync();
            }else
            {
                throw new NotImplementedException();
            }
            
            
            
        }
    }
}
