using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IMethodUseRepository
    {
        Task<IEnumerable<MethodUse>> AllMethodUse();
        MethodUse FindById(int id);
        void AddMethodUse(MethodUse methodUse);
        void DeleteMethodUse(MethodUse methodUse);
        void UpdateMethodUse(MethodUse methodUse);
        bool SaveChanges();
    }
}
