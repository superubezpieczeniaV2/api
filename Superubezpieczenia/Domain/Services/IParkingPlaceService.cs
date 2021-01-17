using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface IParkingPlaceService
    {
        Task<IEnumerable<ParkingPlace>> AllParkingPlace();
        ParkingPlace FindById(int id);
        void AddParkingPlace(ParkingPlace parkingPlace);
        void DeleteParkingPlace(ParkingPlace parkingPlace);
        void UpdateParkingPlace(ParkingPlace parkingPlace);
        bool SaveChanges();
    }
}
