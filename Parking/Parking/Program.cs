using Parking.Classes;
using System;
using System.Collections.Generic;

namespace Parking
{
    class Program
    {
        public static List<Menu> ListOfMenus = new List<Menu>();
        static void Main(string[] args)
        {
            //ShowHistoryForOneMinute, ShowLog, ShowIncomeForOneMinute, ShowCommonIncome
            ListOfMenus.Add(new Menu(StartParking, Exit));
            ListOfMenus.Add(new Menu(AddCar, RemoveCar, ShowCar, TopUpBalance, ShowFreePlaces, Exit));
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
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Truck);
            ListOfMenus[3].Show(false);
        }

        static void PickPassenger()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Passenger);
            ListOfMenus[3].Show(false);
        }

        static void PickBus()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Bus);
            ListOfMenus[3].Show(false);
        }

        static void PickMotorcycle()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Motorcycle);
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

        static void ShowCar()
        {
            Console.Clear();
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Classes.Parking.Instance.ShowCar(id);
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
