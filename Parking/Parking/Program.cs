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
            //ShowHistoryForOneMinute, ShowLog, ShowIncomeForOneMinute, ShowCommonIncome
            ListOfMenus.Add(new Menu(StartParking, Exit));
            ListOfMenus.Add(new Menu(AddCar, RemoveCar, TopUpBalance, ShowFreePlaces, Exit));
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
            Classes.Parking.Instance.AddCar(CarType.Truck);
            ListOfMenus[3].Show(false);
        }

        static void PickPassenger()
        {
            Console.Clear();
            Classes.Parking.Instance.AddCar(CarType.Passenger);
            ListOfMenus[3].Show(false);
        }

        static void PickBus()
        {
            Console.Clear();
            Classes.Parking.Instance.AddCar(CarType.Bus);
            ListOfMenus[3].Show(false);
        }

        static void PickMotorcycle()
        {
            Console.Clear();
            Classes.Parking.Instance.AddCar(CarType.Motorcycle);
            ListOfMenus[3].Show(false);
        }

        static void RemoveCar()
        {
            Console.Clear();
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Classes.Parking.Instance.RemoveCar(id);
            ListOfMenus[3].Show(false);
        }

        static void TopUpBalance()
        {
            Console.Clear();
            Classes.Parking.Instance.TopUpBalance();
            ListOfMenus[3].Show(false);
        }

        static void ShowFreePlaces()
        {
            Console.Clear();
            Classes.Parking.Instance.ShowFreePlaces();
            ListOfMenus[3].Show(false);
        }

        static void TurnBack()
        {
            Console.Clear();
            ListOfMenus[1].Show(false);
        }
    }
}
