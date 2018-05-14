using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public class Transaction
    {
        public DateTime transactionDate { get; set; }
        public string carId { get; set; }
        public double funds { get; set; }
    }

    [DataContract]
    public class SerializeTransactions
    {
        [DataMember]
        public DateTime timeOfSerialization { get; set; }

        [DataMember]
        public double fundsForPreviousMinute { get; set; }
    }
}
