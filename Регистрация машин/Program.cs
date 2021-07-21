using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Регистрация_машин
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSystem ss = new StartSystem();
            ss.ccs.CH = CarStolen;
            Console.WriteLine("1.Press 1 to start 2 to exit");

            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                while(true)
                {
                    ss.StartCheckSys();
                    Thread.Sleep(5000);
                    if (Console.KeyAvailable == true)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Q)
                            break;
                    }
                }
            }

            
            Reporter res = ss.StopSystem();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Кол-во легковых автомобилей: " + res.CarCount);
            Console.WriteLine("Кол-во грузовых автомобилей: " + res.CargoCount);
            Console.WriteLine("Кол-во автобусов: " + res.BusCount);
            Console.WriteLine("Общее кол-во машин: " + res.TotalPassedCars);
            Console.WriteLine("Кол-во машин нарувшие скоростной режим: " + res.TotalSpeedViolatedCars);
            Console.WriteLine("Кол-во машин зафиксированных в угоне: " + res.CountOfStolenCars);

            void CarStolen(AVehicle car, string report)
            {
                Console.WriteLine(report + "\t" + car.ShowInfo());

            }
        }
    }
}
