using Parking.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Program
    {
        public static List<Menu> ListOfMenus = new List<Menu>();
        static void Main(string[] args)
        {
            ListOfMenus.Add(new Menu(StartParking, Settings, Exit));
            ListOfMenus.Add(new Menu(Settings, StartParking, Exit));
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
    }
}
