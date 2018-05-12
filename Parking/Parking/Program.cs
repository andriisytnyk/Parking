using Parking.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            //TopUpBalance, ShowHistoryForOneMinute, ShowLog, ShowIncomeForOneMinute, ShowCommonIncome
            ListOfMenus.Add(new Menu(StartParking, Settings, Exit));
            ListOfMenus.Add(new Menu(AddCar, RemoveCar, ShowFreePlaces, Exit));
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
            Console.Clear();
            ListOfMenus[4].Show(false);
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
            Console.WriteLine("The car was added successfully! Car id: " + Classes.Parking.Instance.ListOfCars[Classes.Parking.Instance.ListOfCars.Count - 1].Id);
            ListOfMenus[3].Show(false);
        }

        static void PickPassenger()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Passenger));
            Console.WriteLine("The car was added successfully! Car id: " + Classes.Parking.Instance.ListOfCars[Classes.Parking.Instance.ListOfCars.Count - 1].Id);
            ListOfMenus[3].Show(false);
        }

        static void PickBus()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Bus));
            Console.WriteLine("The car was added successfully! Car id: " + Classes.Parking.Instance.ListOfCars[Classes.Parking.Instance.ListOfCars.Count - 1].Id);
            ListOfMenus[3].Show(false);
        }

        static void PickMotorcycle()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.ListOfCars.Add(new Car(balance, CarType.Motorcycle));
            Console.WriteLine("The car was added successfully! Car id: " + Classes.Parking.Instance.ListOfCars[Classes.Parking.Instance.ListOfCars.Count - 1].Id);
            ListOfMenus[3].Show(false);
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
            ListOfMenus[3].Show(false);
        }

        static void ShowFreePlaces()
        {
            Console.Clear();
            Console.WriteLine("Count of free parking places: " + (Classes.Parking.Instance.settings.ParkingSpace - Classes.Parking.Instance.ListOfCars.Count) + "/" + Classes.Parking.Instance.settings.ParkingSpace);
            ListOfMenus[3].Show(false);
        }

        static void TurnBack()
        {
            Console.Clear();
            ListOfMenus[1].Show(false);
        }

    }
}
