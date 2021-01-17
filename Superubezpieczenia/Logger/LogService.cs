using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public class LogService :  ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }


        public async Task<IEnumerable<Log>> All()
        {
            return await _logRepository.All();
        }

        public Log FindByDate(DateTime date)
        {
            return _logRepository.FindByDate(date);
        }

        public void Save(string name, string actionName, string controllerName)
        {
            _logRepository.Save(name, actionName, controllerName);
        }
    }   
}
