using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public class Transaction
    {
        static object locker = new object();
        public DateTime Date { get; set; }
        public int IdTrans { get; set; }
        public int IdCar { get; set; }
        public double Tax { get; set; }

        public Transaction(int id, double tax)
        {
            lock(locker)
            {
                Date = DateTime.Now;
                IdTrans = Parking.GlobTransId;
                Parking.GlobTransId++;
                IdCar = id;
                Tax = tax;
            }
        }
    }
}
