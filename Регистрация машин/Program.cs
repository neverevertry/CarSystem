using System;
using System.Collections.Generic;
using System.Linq;

namespace Регистрация_машин
{
    class Program
    {
        static void Main(string[] args)
        {
            CarCheckingSystem css = new CarCheckingSystem();
            ConsoleKeyInfo input;
            int menu = int.Parse(Console.ReadLine());

            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.NumPad1)
                {
                    RandomValuesForMachine rvfm = new RandomValuesForMachine();
                    AVehicle ahv = rvfm.GetRandomVehicle();
                    css.MonitorInfo(ahv);
                    css.Excess(ahv);
                    css.CheckStolenCar(ahv);
                }
                if (input.Key == ConsoleKey.NumPad2)
                {
                    css.MonitorShowIntuder();
                    css.InfoAboutAllCar();
                }

            } while (input.Key!=ConsoleKey.NumPad2);
        }
    }
}
