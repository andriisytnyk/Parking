using Parking.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking
{
    class Program
    {
        public static List<Menu> ListOfMenus = new List<Menu>();
        static void Main(string[] args)
        {
            //TopUpBalance, ShowHistoryForOneMinute, ShowLog, ShowIncomeForOneMinute, ShowCommonIncome, ShowFreePlaces, StopParking
            ListOfMenus.Add(new Menu(StartParking, Settings, Exit));
            ListOfMenus.Add(new Menu(AddCar, RemoveCar));
            ListOfMenus.Add(new Menu(PickTruck, PickPassenger, PickBus, PickMotorcycle));
            ListOfMenus.Add(new Menu(TurnBack));
            ListOfMenus[0].Show(false);
        }

        static void StartParking()
        {
            var parking = Classes.Parking.Instance;
            Console.Clear();
            ListOfMenus[1].Show(false);
        }

        static void Settings()
        {

        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        static void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Choose a type of your car: ");
            ListOfMenus[2].Show(false);
        }

        static void PickTruck()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Truck));
            Console.WriteLine("The car was added successfully!");
            Thread.Sleep(1500);
            ListOfMenus[1].Show(false);
        }

        static void PickPassenger()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Passenger));
            Console.WriteLine("The car was added successfully!");
            Thread.Sleep(1500);
            ListOfMenus[1].Show(false);
        }

        static void PickBus()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Bus));
            Console.WriteLine("The car was added successfully!");
            Thread.Sleep(1500);
            ListOfMenus[1].Show(false);
        }

        static void PickMotorcycle()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Motorcycle));
            Console.WriteLine("The car was added successfully!");
            Thread.Sleep(1500);
            ListOfMenus[1].Show(false);
        }

        static void RemoveCar()
        {
            Console.Clear();
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var car = Classes.Parking.Instance.ListOfCars.Find(obj => obj.Id == id);
                Classes.Parking.Instance.ListOfCars.Remove(car);
            }
            catch
            {
                Console.WriteLine("Check id you wrote. Was not found anyone car with such id!");
                Thread.Sleep(2000);
                Console.Clear();
                ListOfMenus[1].Show(false);
            }
            Console.WriteLine("Your car was removed successfully!");
            Thread.Sleep(1500);
            Console.Clear();
            ListOfMenus[1].Show(false);
        }

        static void TurnBack()
        {
            Console.Clear();
            ListOfMenus[1].Show(false);
        }
    }
}
