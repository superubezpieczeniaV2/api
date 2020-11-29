using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> AllCars();
        void AddCar(Car car);
        bool SaveChanges();
    }
}
