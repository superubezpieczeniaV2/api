using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface ICarServices
    {
        Task<IEnumerable<Car>> AllCars();
        void AddCar(Car car);
        bool SaveChanges();
    }
}
