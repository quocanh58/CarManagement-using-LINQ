using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibraby.BussinessObject;

namespace AutomobileLibraby.DataAccess
{
    public class CarDBContent
    {
        private static List<Car> CarList = new List<Car>()
        {
            new Car
            {
                CarId = 1, CarName = "CRV", Manufacturer = "Honda", Price=30000, ReleaseYear=2021
            },
            new Car
            {
                CarId = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price=15000, ReleaseYear=2020
            },
        };
        //using singleton pattern

        private static CarDBContent instance = null;
        public static readonly object instanceLock = new object();
        private CarDBContent() { }
        public static CarDBContent Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContent();
                    }
                    return instance;
                }
            }
        }
        //Initialize car list
        public List<Car> GetCarList => CarList;

        //GetCarList by iD
        public Car GetCarByID(int carID)
        {
            //LINQ to object
            Car car = CarList.SingleOrDefault(pro => pro.CarId == carID);
            return car;
        }

        //ADD new car
        public void AddNewCar(Car car)
        {
            Car pro = GetCarByID(car.CarId);
            if (pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exist !");
            }
        }

        //Update car
        public void updateCar(Car car)
        {
            Car c2 = GetCarByID(car.CarId);
            if (c2 != null)
            {
                var index = CarList.IndexOf(c2);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car doesn't already exist !");
            }
        }

        //Delete Car
        public void deleteCar(int carId)
        {
            Car c3 = GetCarByID(carId);
            if (c3 != null)
            {
                CarList.Remove(c3);
            }
            else
            {
                throw new Exception("Car doesn't already exist !");
            }
        }
    }
}
