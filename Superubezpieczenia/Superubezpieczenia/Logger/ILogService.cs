using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public interface  ILogService
    {
        public void Save(string name, string actionName, string controllerName);
        Task<IEnumerable<Log>> All();
        Log FindByDate(DateTime date);
    }
}
