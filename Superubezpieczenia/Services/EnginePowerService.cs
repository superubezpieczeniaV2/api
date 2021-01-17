using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class EnginePowerService : IEnginePowerService
    {
        public readonly IEnginePowerRepository _enginePowerRepository;
        public EnginePowerService(IEnginePowerRepository enginePowerRepository)
        {
            _enginePowerRepository = enginePowerRepository;

        }
        public void AddEnginePower(EnginePower enginePower)
        {
            _enginePowerRepository.AddEnginePower(enginePower);
        }

        public async Task<IEnumerable<EnginePower>> AllEnginePower()
        {
            return await _enginePowerRepository.AllEnginePower();
        }

        public void DeleteEnginePower(EnginePower enginePower)
        {
            _enginePowerRepository.DeleteEnginePower(enginePower);
        }

        public EnginePower FindById(int id)
        {
            return _enginePowerRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _enginePowerRepository.SaveChanges();
        }

        public void UpdateEnginePower(EnginePower enginePower)
        {
            _enginePowerRepository.UpdateEnginePower(enginePower);
        }
    }
}
