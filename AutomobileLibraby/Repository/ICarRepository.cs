using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibraby.BussinessObject;

namespace AutomobileLibraby.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCar();
        Car GetCarById(int CarID);
        void InsertCar(Car car);
        void DeleteCar(int CarID);
        void UpdateCar(Car car);
    }
}
