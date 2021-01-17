using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public class LogRepository : LogBase, ILogRepository
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Log>> All()
        {
            return await _context.Loggers.ToListAsync();
        }

        public Log  FindByDate(DateTime date)
        {
            return (Log)_context.Loggers.Where(x => x.DataLog == date );
        }

        public void Save(string name, string actionName, string controllerName)
        {
            Log logDTO = new Log();
            logDTO.ControllerName = controllerName;
            logDTO.UserName = name;
            logDTO.DataLog = DateTime.Now;
            logDTO.ActionName = actionName;
            _context.Loggers.Add(logDTO);
            _context.SaveChanges();


        }
    }
}
