using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class TypeFuelService : ITypeFuelService
    {
        public readonly ITypeFuelRepository _typeFuelRepository;
        public TypeFuelService(ITypeFuelRepository typeFuelRepository)
        {
            _typeFuelRepository = typeFuelRepository;
        }
        public void AddTypeFuel(TypeFuel typeFuel)
        {
            _typeFuelRepository.AddTypeFuel(typeFuel);
        }

        public async Task<IEnumerable<TypeFuel>> AllTypeFuel()
        {
            return await _typeFuelRepository.AllTypeFuel();
        }

        public void DeleteTypeFuel(TypeFuel typeFuel)
        {
            _typeFuelRepository.DeleteTypeFuel(typeFuel);
        }

        public TypeFuel FindById(int id)
        {
            return _typeFuelRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _typeFuelRepository.SaveChanges();
        }

        public void UpdateTypeFuel(TypeFuel typeFuel)
        {
            _typeFuelRepository.UpdateTypeFuel(typeFuel);
        }
    }
}
