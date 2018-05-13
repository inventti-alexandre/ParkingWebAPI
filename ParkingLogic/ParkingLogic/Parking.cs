using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public class Parking
    {
        private static Dictionary<CarType, double> PriceList = Settings.GetPriceList();
        private static int Timeout = Settings.Timeout;
        private static double Fine = Settings.Fine;
        private static int ParkingSpace = Settings.ParkingSpace;
        private static string TransactionLogFileName = Settings.TransactionLogFileName;

        private List<Car> Cars;
        private List<Transaction> Transactions;

        private double ParkingBalance;

        private static readonly Lazy<Parking> instance = new Lazy<Parking>(() => new Parking());

        private Parking()
        {

            Cars = new List<Car>(ParkingSpace);
            Transactions = new List<Transaction>();

            ParkingBalance = 0;

            TimerCallback calculateFunds = new TimerCallback(CalculateFundsForAllCars);
            Timer timer1 = new Timer(calculateFunds, null, 0, Timeout);

            TimerCallback serializeToFile = new TimerCallback(SerializeToFile);
            Timer timer2 = new Timer(serializeToFile, null, 0, 60000);


        }

        public static Parking GetInstance()
        {
            return instance.Value;
        }

        public double GetParkingRevenue()
        {
            return ParkingBalance;
        }

        public void AddCar(Car car)
        {
            if (Cars.Count() < ParkingSpace)
            {
                Cars.Add(car);
            }
            else
            {
                Console.WriteLine("The parking is overloaded!");
            }
        }

        public List<Car> GetAllCars()
        {
            return Cars;
        }

        public List<Transaction> GetAllTransactions()
        {
            return Transactions;
        }

        public void AddCarBalance(double newBalance, Car car)
        {
            car.Balance += newBalance;
        }

        public void RemoveCar(Car car)
        {
            Cars.Remove(car);
        }

        public int AvailablePlaces()
        {
            return ParkingSpace - Cars.Count;
        }


        public void CalculateFee(double newBalance, Car car)
        {
            ParkingBalance += newBalance;
            Transactions.Add(new Transaction
            {
                transactionDate = DateTime.Now,
                carId = car.Id,
                funds = newBalance
            });
        }

        private void CalculateFundsForAllCars(object obj)
        {
            foreach (Car car in Cars)
            {
                double priceForCar = PriceList[car.Type];
                if (car.Balance < priceForCar)
                {
                    car.Balance -= priceForCar * Fine;
                }
                else
                {
                    car.Balance -= priceForCar;
                    ParkingBalance += priceForCar;
                    Transactions.Add(new Transaction
                    {
                        transactionDate = DateTime.Now,
                        carId = car.Id,
                        funds = priceForCar
                    });
                }
            }
        }


        private void SerializeToFile(object obj)
        {

            List<SerializeTransactions> previousTransactions = this.DeserializeFromFile();

            SerializeTransactions transactionsForPreviousMinute = new SerializeTransactions()
            {
                timeOfSerialization = DateTime.Now,
                fundsForPreviousMinute = Transactions.Select(x => x.funds).Sum()
            };


            previousTransactions.Add(transactionsForPreviousMinute);


            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SerializeTransactions>));
            using (FileStream fs = new FileStream(TransactionLogFileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, previousTransactions);

                Console.WriteLine("All transactions were serialized to Transaction.log file");
            }


            Transactions = new List<Transaction>();
        }



        public List<SerializeTransactions> DeserializeFromFile()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SerializeTransactions>));
            List<SerializeTransactions> transactionLog;

            try
            {
                using (FileStream fs = new FileStream(TransactionLogFileName, FileMode.OpenOrCreate))
                {
                    transactionLog = (List<SerializeTransactions>)jsonFormatter.ReadObject(fs);

                }
            }
            catch (SerializationException)
            {
                transactionLog = new List<SerializeTransactions>();
            }

            return transactionLog;
        }

    }
}
