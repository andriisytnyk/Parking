using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public class Transaction
    {
        private readonly object _locker = new object();
        public DateTime Date { get; set; }
        public int IdTrans { get; set; }
        public int IdCar { get; set; }
        public double Tax { get; set; }

        public Transaction(int id, double tax)
        {
            lock(_locker)
            {
                Date = DateTime.Now;
                IdTrans = Parking.GlobTransId;
                Parking.GlobTransId++;
                IdCar = id;
                Tax = tax;
            }
        }

        public override string ToString()
        {
            return "Transaction id: " + IdTrans + "\nCar id: " + IdCar + "\nSum of transaction: " + Tax + "\nDate: " + Date + "\n";
        }
    }
}
