using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class ParkingPalceRepository : BaseRepository, IParkingPlaceRepository
    {
        public ParkingPalceRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public void AddParkingPlace(ParkingPlace parkingPlace)
        {
            _context.ParkingPlaces.Add(parkingPlace);
        }

        public async Task<IEnumerable<ParkingPlace>> AllParkingPlace()
        {
            return await _context.ParkingPlaces.ToListAsync();
        }

        public void DeleteParkingPlace(ParkingPlace parkingPlace)
        {
            _context.ParkingPlaces.Remove(parkingPlace);
        }

        public ParkingPlace FindById(int id)
        {
            return _context.ParkingPlaces.FirstOrDefault(p => p.IDParkingPlace == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateParkingPlace(ParkingPlace parkingPlace)
        {
            
        }
    }
}
