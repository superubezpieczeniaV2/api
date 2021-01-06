using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public abstract class LogBase
    {
        protected readonly ApplicationDbContext _context;
        

        public LogBase(ApplicationDbContext context)
        {
            _context = context;

        }

       
    
    }
}
