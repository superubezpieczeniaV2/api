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
    public class CarRepository : BaseRepository, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public async Task<IEnumerable<Car>> AllCars()
        {

            return await _context.Cars.ToListAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
