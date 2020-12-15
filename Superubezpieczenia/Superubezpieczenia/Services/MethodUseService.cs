using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class MethodUseService : IMethodUseService
    {
        public readonly IMethodUseRepository _methodUseRepository;
        public MethodUseService(IMethodUseRepository methodUseRepository)
        {
            _methodUseRepository = methodUseRepository;
        }

        public void AddMethodUse(MethodUse methodUse)
        {
            _methodUseRepository.AddMethodUse(methodUse);
        }

        public async Task<IEnumerable<MethodUse>> AllMethodUse()
        {
            return await _methodUseRepository.AllMethodUse();
        }

        public void DeleteMethodUse(MethodUse methodUse)
        {
            _methodUseRepository.DeleteMethodUse(methodUse);
        }

        public MethodUse FindById(int id)
        {
            return _methodUseRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _methodUseRepository.SaveChanges();
        }

        public void UpdateMethodUse(MethodUse methodUse)
        {
            _methodUseRepository.UpdateMethodUse(methodUse);
        }
    }
}
