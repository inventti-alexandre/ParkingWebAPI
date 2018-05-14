using ParkingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWebAPI.Services
{
    public class ParkingService
    {
        public ParkingService()
        {
            parking = Parking.GetInstance();
        }
        public Parking parking { get; set; }

        public Car AddCar(double Balance, CarType Type)
        {
            if(Balance <= 0)
            {
                throw new Exception("The Balance is 0 or negative");
            }

            if(! Enum.IsDefined(typeof(CarType), Type))
            {
                throw new Exception("The mandatory parameter Type was missed or not valid");
            }
            Car newCar = new Car(Type, Balance, Guid.NewGuid().ToString());
            parking.AddCar(newCar);
            return newCar;
        }

        public List<Car> GetAllCars()
        {
            return parking.GetAllCars();
        }

        public Car GetCarById(string id)
        {
            return parking.GetAllCars().Find(x => x.Id == id);
        }

        public void RemoveCar(string id)
        {
            Car carToRemove = parking.GetAllCars().Find(x => x.Id == id);
            if(carToRemove.Balance < 0)
            {
                throw new Exception();
            }
            else
            {
                parking.RemoveCar(carToRemove);
            }
        }

       
    }
}
