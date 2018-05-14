using ParkingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWebAPI.Models
{
    public class CarFormDataModel
    {
        public double Balance { get; set; }
        public CarType Type { get; set; }
    }
}
