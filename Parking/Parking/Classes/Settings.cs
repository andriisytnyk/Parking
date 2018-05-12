using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Configuration.ConfigurationManager;

namespace Parking.Classes
{
    public class Settings
    {
        public Dictionary<CarType, int> Prices { get; protected set; }
        public int TimeOut { get; protected set; }
        public int ParkingSpace { get; protected set; }
        public double Fine { get; protected set; }

        public Settings()
        {
            SettingsReader();
        }

        private void SettingsReader()
        {
            var generalSettings = (GetSection("parkingSettings/generalSettings") as System.Collections.Hashtable)
                    .Cast <System.Collections.DictionaryEntry>()
                    .ToDictionary(item => item.Key.ToString(), item => item.Value.ToString());
            TimeOut = Convert.ToInt32(generalSettings["TimeOut"]);
            ParkingSpace = Convert.ToInt32(generalSettings["ParkingSpace"]);
            Fine = Convert.ToDouble(generalSettings["Fine"]);

            Prices = new Dictionary<CarType, int>();

            var paymentSettings = (GetSection("parkingSettings/paymentSettings") as System.Collections.Hashtable)
                    .Cast<System.Collections.DictionaryEntry>()
                    .ToDictionary(item => item.Key.ToString(), item => item.Value.ToString());
            Prices[CarType.Truck] = Convert.ToInt32(paymentSettings["Truck"]);
            Prices[CarType.Passenger] = Convert.ToInt32(paymentSettings["Passenger"]);
            Prices[CarType.Bus] = Convert.ToInt32(paymentSettings["Bus"]);
            Prices[CarType.Motorcycle] = Convert.ToInt32(paymentSettings["Motorcycle"]);
        }
    }
}
