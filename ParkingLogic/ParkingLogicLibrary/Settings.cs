using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public static class Settings
    {
        private static Dictionary<CarType, double> PriceList = new Dictionary<CarType, double>()
        {
            {CarType.Motorcycle, 1},
            {CarType.Bus, 2},
            {CarType.Passenger, 3},
            {CarType.Truck, 4}
        };

        public static Dictionary<CarType, double> GetPriceList()
        {
            return PriceList;
        }

        public static void ChangePriceList(Dictionary<CarType, double> priceList)
        {
            PriceList = priceList;
        }

        public static int Timeout { get; set; } = 3000;

        public static int ParkingSpace { get; set; } = 20;

        public static double Fine { get; set; } = 2;

        public static string TransactionLogFileName { get; set; } = "Transaction.log";


    }
}
