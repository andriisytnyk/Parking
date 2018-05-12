using Parking.Classes;
using System;
using System.Collections.Generic;

namespace Parking
{
    public class Program
    {
        public static List<Menu> ListOfMenus = new List<Menu>();

        private static void Main(string[] args)
        {
            ListOfMenus.Add(new Menu(StartParking, Exit));
            ListOfMenus.Add(new Menu(AddCar, RemoveCar, ShowCar, TopUpBalance, ShowFreePlaces, ShowLog, ShowHistoryForOneMinute, ShowCommonIncome, ShowIncomeForOneMinute, Exit));
            ListOfMenus.Add(new Menu(PickTruck, PickPassenger, PickBus, PickMotorcycle));
            ListOfMenus.Add(new Menu(TurnBack));
            ListOfMenus[0].Show(false);
        }

        private static void StartParking()
        {
            var parking = Classes.Parking.Instance;
            Console.Clear();
            ListOfMenus[1].Show(false);
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Choose a type of your car: ");
            ListOfMenus[2].Show(false);
        }

        private static void PickTruck()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Truck);
            ListOfMenus[3].Show(false);
        }

        private static void PickPassenger()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Passenger);
            ListOfMenus[3].Show(false);
        }

        private static void PickBus()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Bus);
            ListOfMenus[3].Show(false);
        }

        private static void PickMotorcycle()
        {
            Console.Clear();
            Console.WriteLine("Write a balance of your car: ");
            var balance = Convert.ToDouble(Console.ReadLine());
            Classes.Parking.Instance.AddCar(balance, CarType.Motorcycle);
            ListOfMenus[3].Show(false);
        }

        private static void RemoveCar()
        {
            Console.Clear();
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Classes.Parking.Instance.RemoveCar(id);
            ListOfMenus[3].Show(false);
        }

        private static void ShowCar()
        {
            Console.Clear();
            Console.WriteLine("Write id of your car: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Classes.Parking.Instance.ShowCar(id);
            ListOfMenus[3].Show(false);
        }

        private static void TopUpBalance()
        {
            Console.Clear();
            Classes.Parking.Instance.TopUpBalance();
            ListOfMenus[3].Show(false);
        }

        private static void ShowFreePlaces()
        {
            Console.Clear();
            Classes.Parking.Instance.ShowFreePlaces();
            ListOfMenus[3].Show(false);
        }

        private static void ShowLog()
        {
            Console.Clear();
            List<string> listLog = Classes.Parking.Instance.GetLog();
            foreach (var item in listLog)
            {
                Console.WriteLine(item);
            }
            ListOfMenus[3].Show(false);
        }

        private static void ShowHistoryForOneMinute()
        {
            Console.Clear();
            var time = DateTime.Now;
            time = time.AddMinutes(-1);
            foreach (var item in Classes.Parking.Instance.ListOfTransactions)
            {
                if (item.Date >= time)
                {
                    Console.WriteLine(item.ToString());
                }
                else
                {
                    Classes.Parking.Instance.ListOfTransactions.Remove(item);
                }
            }
            ListOfMenus[3].Show(false);
        }

        private static void ShowCommonIncome()
        {
            Console.Clear();
            Console.WriteLine("Common Income: " + Classes.Parking.Instance.Income);
            ListOfMenus[3].Show(false);
        }

        private static void ShowIncomeForOneMinute()
        {
            Console.Clear();
            var time = DateTime.Now;
            time = time.AddMinutes(-1);
            double sum = 0;
            foreach (var item in Classes.Parking.Instance.ListOfTransactions)
            {
                if (item.Date >= time)
                {
                    sum += item.Tax;
                }
                else
                {
                    Classes.Parking.Instance.ListOfTransactions.Remove(item);
                }
            }
            Console.WriteLine("Income for last minute: " + sum);
            ListOfMenus[3].Show(false);
        }

        private static void TurnBack()
        {
            Console.Clear();
            ListOfMenus[1].Show(false);
        }
    }
}
