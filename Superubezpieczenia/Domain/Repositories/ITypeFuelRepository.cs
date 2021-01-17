using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public interface ITypeFuelRepository
    {
        Task<IEnumerable<TypeFuel>> AllTypeFuel();
        TypeFuel FindById(int id);
        void AddTypeFuel(TypeFuel typeFuel);
        void DeleteTypeFuel(TypeFuel typeFuel);
        void UpdateTypeFuel(TypeFuel typeFuel);
        bool SaveChanges();
    }
}
