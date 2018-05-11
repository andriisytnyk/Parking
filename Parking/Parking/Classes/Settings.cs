using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    class Settings
    {
        Dictionary<CarType, int> prices;
        public int TimeOut { get; set; }
        public int ParkingSpace { get; set; }
        public double Fine { get; set; }

        public Settings()
        {
            prices = new Dictionary<CarType, int>()
            {
                { CarType.Truck, 5 },
                { CarType.Passenger, 3 },
                { CarType.Bus, 2 },
                { CarType.Motorcycle, 1 }
            };
            TimeOut = 3;
            ParkingSpace = 50;
            Fine = 1.1;
        }

        public void FileReader()
        {

        }
    }
}
