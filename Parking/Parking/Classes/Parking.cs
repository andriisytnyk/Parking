using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Parking.Classes
{
    public class Parking
    {
        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return Lazy.Value; } }

        public string TransactionFileName { get; } = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + "\\AppData\\Transactions.log";

        public static int GlobCarId { get; set; }
        public static int GlobTransId { get; set; }

        private readonly Settings _settings;

        public List<Car> ListOfCars { get; }
        public List<Transaction> ListOfTransactions { get; }

        private readonly TimerCallback _tcbTrans;
        private readonly Dictionary<Car, Timer> _dictTimers;

        public double Income { get; private set; }

        private Parking()
        {
            GlobCarId = 1;
            GlobTransId = 1;
            _settings = new Settings();
            ListOfCars = new List<Car>();
            ListOfTransactions = new List<Transaction>();
            _tcbTrans = new TimerCallback(Transaction);
            _dictTimers = new Dictionary<Car, Timer>();
            var tcbSunTrans = new TimerCallback(SumOfTransactions);
            var timer = new Timer(tcbSunTrans, null, 20000, 20000);
            Income = 0;
        }

        ~Parking()
        {
            foreach (var item in _dictTimers)
            {
                item.Value.Dispose();
            }
        }

        public void AddCar(double balance, CarType type)
        {
            ListOfCars.Add(new Car(balance, type));
            var id = ListOfCars[ListOfCars.Count - 1].Id;
            Console.WriteLine("The car was added successfully! Car id: " + id);

            _dictTimers.Add(ListOfCars[ListOfCars.Count - 1], new Timer(_tcbTrans, id, _settings.TimeOut * 1000, _settings.TimeOut * 1000));
        }

        public void RemoveCar(int id)
        {
            try
            {
                var car = Instance.ListOfCars.Find(obj => obj.Id == id);
                _dictTimers[car].Dispose();
                _dictTimers.Remove(car);
                Instance.ListOfCars.Remove(car);
            }
            catch
            {
                Console.WriteLine("Check id you wrote. Was not found anyone car with such id!");
            }
            Console.WriteLine("Your car was removed successfully!");
        }

        public void ShowCar(int id)
        {
            try
            {
                var car = Instance.ListOfCars.Find(obj => obj.Id == id);
                Console.WriteLine("Type of your car: " + car.Type);
                Console.WriteLine("Balance of your car: " + car.Balance);
                Console.WriteLine("Fine of your car: " + car.Fine);
            }
            catch
            {
                Console.WriteLine("Check id you wrote. Was not found anyone car with such id!");
            }
        }

        public void TopUpBalance()
        {
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            int index = Instance.ListOfCars.FindIndex(car => car.Id == Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Write count of money for adding to balance of your car: ");
            double money = Convert.ToDouble(Console.ReadLine());
            if (Instance.ListOfCars[index].Fine == 0)
            {
                Instance.ListOfCars[index].Balance += money;
            }
            else
            {
                if (money <= Instance.ListOfCars[index].Fine)
                {
                    Instance.ListOfCars[index].Fine -= money;
                    Income += money;
                    ListOfTransactions.Add(new Transaction(id, money));
                }
                else
                {
                    Income += Instance.ListOfCars[index].Fine;
                    ListOfTransactions.Add(new Transaction(id, Instance.ListOfCars[index].Fine));
                    Instance.ListOfCars[index].Balance += money - Instance.ListOfCars[index].Fine;
                    Instance.ListOfCars[index].Fine = 0;
                }
            }
            Console.WriteLine("Balance of your car was changed successfully!");
        }

        public void ShowFreePlaces()
        {
            Console.WriteLine("Count of free parking places: " + (Instance._settings.ParkingSpace - Instance.ListOfCars.Count) + "/" + Instance._settings.ParkingSpace);
        }

        private void Transaction(object obj)
        {
            var id = (int)obj;
            var indexOfCar = ListOfCars.FindIndex(car => car.Id == id);
            double priceOfTrans = _settings.Prices[ListOfCars[indexOfCar].Type];
            if (priceOfTrans > ListOfCars[indexOfCar].Balance)
            {
                priceOfTrans *= _settings.Fine;
                ListOfCars[indexOfCar].Fine += priceOfTrans;
            }
            else
            {
                ListOfCars[indexOfCar].Balance -= priceOfTrans;
                Income += priceOfTrans;
                ListOfTransactions.Add(new Transaction(id, priceOfTrans));
            }
        }

        private void SumOfTransactions(object obj)
        {
            double sum = 0;
            var time = DateTime.Now;
            time = time.AddMinutes(-1);
            foreach (var item in ListOfTransactions)
            {
                if (item.Date >= time)
                {
                    sum += item.Tax;
                }
                else
                {
                    ListOfTransactions.Remove(item);
                }
            }

            if (File.Exists(TransactionFileName))
            {
                using (var sw = new StreamWriter(TransactionFileName, true))
                {
                    sw.WriteLine("Sum: " + sum + ", time: " + time);
                }
            }
        }

        public List<string> GetLog()
        {
            var list = new List<string>();
            if (File.Exists(TransactionFileName))
            {
                using (var sr = new StreamReader(TransactionFileName))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }
    }
}
