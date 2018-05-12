using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        public static int GlobCarId { get; set; }
        public static int GlobTransId { get; set; }

        private readonly Settings settings;

        private List<Car> ListOfCars;
        private List<Transaction> ListOfTransactions;

        private TimerCallback tcb;
        private Dictionary<Car, Timer> dictTimers;
        
        private double income { get; set; }

        private Parking()
        {
            GlobCarId = 1;
            GlobTransId = 1;
            settings = new Settings();
            ListOfCars = new List<Car>();
            ListOfTransactions = new List<Transaction>();
            tcb = new TimerCallback(Instance.Transaction);
            dictTimers = new Dictionary<Car, Timer>();
            income = 0;
        }

        ~Parking()
        {

        }

        public void AddCar(CarType type)
        {
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            ListOfCars.Add(new Car(balance, type));
            var id = Instance.ListOfCars[Instance.ListOfCars.Count - 1].Id;
            Console.WriteLine("The car was added successfully! Car id: " + id);

            dictTimers.Add(ListOfCars[id], new Timer(tcb, id, Instance.settings.TimeOut * 1000, Instance.settings.TimeOut * 1000));
        }

        public void RemoveCar(int id)
        {
            try
            {
                var car = Instance.ListOfCars.Find(obj => obj.Id == id);
                dictTimers[car].Dispose();
                dictTimers.Remove(car);
                Instance.ListOfCars.Remove(car);
            }
            catch
            {
                Console.WriteLine("Check id you wrote. Was not found anyone car with such id!");
            }
            Console.WriteLine("Your car was removed successfully!");
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
                    income += money;
                    ListOfTransactions.Add(new Transaction(id, money));
                }
                else
                {
                    income += Instance.ListOfCars[index].Fine;
                    ListOfTransactions.Add(new Transaction(id, Instance.ListOfCars[index].Fine));
                    Instance.ListOfCars[index].Balance += money - Instance.ListOfCars[index].Fine;
                    Instance.ListOfCars[index].Fine = 0;
                }
            }
            Console.WriteLine("Balance of your car was changed successfully!");
        }

        public void ShowFreePlaces()
        {
            Console.WriteLine("Count of free parking places: " + (Instance.settings.ParkingSpace - Instance.ListOfCars.Count) + "/" + Instance.settings.ParkingSpace);
        }

        private void Transaction(object obj)
        {
            var id = (int)obj;
            var indexOfCar = ListOfCars.FindIndex(car => car.Id == id);
            double priceOfTrans = settings.prices[ListOfCars[indexOfCar].Type];
            if (priceOfTrans > ListOfCars[indexOfCar].Balance)
            {
                priceOfTrans *= settings.Fine;
                ListOfCars[indexOfCar].Fine += priceOfTrans;
            }
            else
            {
                ListOfCars[indexOfCar].Balance -= priceOfTrans;
                income += priceOfTrans;
                ListOfTransactions.Add(new Transaction(id, priceOfTrans));
            }
        }
    }
}
