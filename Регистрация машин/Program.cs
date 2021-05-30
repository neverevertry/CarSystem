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
            Console.WriteLine("1.Press 1 to start 2 to exit");

            do
            {
                input = Console.ReadKey();
                RandomVehicleGenerator rvfm = new RandomVehicleGenerator();
                AVehicle ahv = rvfm.GenerateRandomVehicle();
                css.MonitorInfo(ahv);
                css.Excess(ahv);
                css.CheckStolenCar(ahv);

            } while (input.Key!=ConsoleKey.NumPad2);
            css.MonitorShowIntuder();
            css.InfoAboutAllCar();
        }
    }
}
