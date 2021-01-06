using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Logger
{
    public interface  ILog
    {
        public  void Save(string name, string actionName, string controllerName);
    }
}
