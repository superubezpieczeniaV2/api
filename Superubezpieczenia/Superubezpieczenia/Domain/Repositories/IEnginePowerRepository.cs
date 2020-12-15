using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IEnginePowerRepository
    {
        Task<IEnumerable<EnginePower>> AllEnginePower();
        EnginePower FindById(int id);
        void AddEnginePower(EnginePower enginePower);
        void DeleteEnginePower(EnginePower enginePower);
        void UpdateEnginePower(EnginePower enginePower);
        bool SaveChanges();
    }
}
