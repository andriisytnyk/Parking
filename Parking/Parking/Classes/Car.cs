using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public enum CarType { Passenger, Truck, Bus, Motorcycle};

    public class Car
    {
        object locker = new object();
        public int Id { get; set; }
        public double Balance { get; set; }
        public CarType Type { get; set; }

        public Car(double balance, CarType type)
        {
            lock(locker)
            {
                Id = Parking.GlobCarId;
                Parking.GlobCarId++;
                Balance = balance;
                Type = type;
            }
        }
    }
}
