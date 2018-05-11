using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        public static int GlobCarId { get; set; }
        public static int GlobTransId { get; set; }

        public readonly Settings settings;

        public List<Car> ListOfCars;
        public List<Transaction> ListOfTransactions;
        public double income { get; protected set; }

        private Parking()
        {
            GlobCarId = 1;
            GlobTransId = 1;
            settings = new Settings();
            ListOfCars = new List<Car>();
            ListOfTransactions = new List<Transaction>();
            income = 0;
        }
    }
}
