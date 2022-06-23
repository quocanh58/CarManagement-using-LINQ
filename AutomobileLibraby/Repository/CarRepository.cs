using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibraby.BussinessObject;
using AutomobileLibraby.DataAccess;

namespace AutomobileLibraby.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(int carID) => CarDBContent.Instance.deleteCar(carID);

        public IEnumerable<Car> GetCar() => CarDBContent.Instance.GetCarList;

        public Car GetCarById(int CarID) => CarDBContent.Instance.GetCarByID(CarID);

        public void InsertCar(Car car) => CarDBContent.Instance.AddNewCar(car);

        public void UpdateCar(Car car) => CarDBContent.Instance.updateCar(car);
    }
}
