using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IParkingPlaceRepository
    {
        Task<IEnumerable<ParkingPlace>> AllParkingPlace();
        ParkingPlace FindById(int id);
        void AddParkingPlace(ParkingPlace parkingPlace);
        void DeleteParkingPlace(ParkingPlace parkingPlace);
        void UpdateParkingPlace(ParkingPlace parkingPlace);
        bool SaveChanges();
    }
}
