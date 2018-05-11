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
        public int Id { get; set; }
        public double Tax { get; set; }

        public Transaction(double tax)
        {
            lock(locker)
            {
                Date = DateTime.Now;
                Id = Parking.GlobTransId;
                Parking.GlobTransId++;
                Tax = tax;
            }
        }
    }
}
