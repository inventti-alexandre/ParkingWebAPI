using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public enum CarType
    {
        Passenger = 1,
        Truck,
        Bus,
        Motorcycle
    }

    public class Car
    {
        public string Id { get; set; }
        public double Balance { get; set; }
        public CarType Type { get; set; }

        public Car(CarType carType, double Balance, string Id)
        {
            this.Id = Id;
            this.Type = carType;
            this.Balance = Balance;
        }
    }
}
