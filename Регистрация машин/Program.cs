using System;
using System.Collections.Generic;
using System.Linq;

namespace Регистрация_машин
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSystem ss = new StartSystem();
            ConsoleKeyInfo input;
            Console.WriteLine("1.Press 1 to start 2 to exit");

            do
            {
                input = Console.ReadKey();
                ss.StartCheckSys();

            } while (input.Key!=ConsoleKey.NumPad2);

            
            Reporter res = ss.StopSystem();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Кол-во легковых автомобилей: " + res.CarCount);
            Console.WriteLine("Кол-во грузовых автомобилей: " + res.CargoCount);
            Console.WriteLine("Кол-во автобусов: " + res.BusCount);
            Console.WriteLine("Общее кол-во машин: " + res.TotalPassedCars);
            Console.WriteLine("Кол-во машин нарувшие скоростной режим: " + res.TotalSpeedViolatedCars);
            Console.WriteLine("Кол-во машин зафиксированных в угоне: " + res.CountOfStolenCars);
        }
    }
}
