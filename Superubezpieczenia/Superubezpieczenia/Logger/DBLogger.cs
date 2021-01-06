using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public class DBLogger : LogBase, ILog
    {
        public DBLogger(ApplicationDbContext context) : base(context)
        {

        }

        public void Save(string name, string actionName)
        {
            Log logDTO = new Log();
            logDTO.ControllerName = GetType().Name;
            logDTO.UserName = name;
            logDTO.DataLog = DateTime.Now;
            logDTO.ActionName = actionName;
            _context.Loggers.Add(logDTO);
            _context.SaveChanges();


        }

        
        
    }
}
