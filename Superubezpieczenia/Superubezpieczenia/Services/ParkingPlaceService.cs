using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class ParkingPlaceService : IParkingPlaceService
    {
        public readonly IParkingPlaceRepository _parkingPlaceRepository;
        public ParkingPlaceService(IParkingPlaceRepository parkingPlaceRepository)
        {
            _parkingPlaceRepository = parkingPlaceRepository;
        }

        public void AddParkingPlace(ParkingPlace parkingPlace)
        {
            _parkingPlaceRepository.AddParkingPlace(parkingPlace);
        }

        public async Task<IEnumerable<ParkingPlace>> AllParkingPlace()
        {
            return await _parkingPlaceRepository.AllParkingPlace();
        }

        public void DeleteParkingPlace(ParkingPlace parkingPlace)
        {
            _parkingPlaceRepository.DeleteParkingPlace(parkingPlace);
        }

        public ParkingPlace FindById(int id)
        {
            return _parkingPlaceRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _parkingPlaceRepository.SaveChanges();
        }

        public void UpdateParkingPlace(ParkingPlace parkingPlace)
        {
            _parkingPlaceRepository.UpdateParkingPlace(parkingPlace);
        }
    }
}
