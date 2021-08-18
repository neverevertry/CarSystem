using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VehicleRegistrator.Bussines;

namespace Register_car
{
    class Program
    {
        static void Main(string[] args)
        {
            CarCheckingSystem ccs = new CarCheckingSystem();
            ccs.HandlerInfoCar += CarInfo;
            Console.WriteLine("1.Press S to start Q to exit, I to import Car into base to system");

            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                while(true)
                {
                    ccs.StartSystem();
                    Thread.Sleep(5000);
                    if (Console.KeyAvailable == true)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Q)
                            break;
                        if (Console.ReadKey(true).Key == ConsoleKey.I)
                        {
                            IReadToListAvehicle rtla = new ReadIntoFileToListAvehicle();
                            ccs.ImportNumberStoleCars(rtla);
                        }
                    }
                }
            }

            Reporter res = ccs.StopSystem();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Кол-во легковых автомобилей: " + res.CarCount);
            Console.WriteLine("Кол-во грузовых автомобилей: " + res.CargoCount);
            Console.WriteLine("Кол-во автобусов: " + res.BusCount);
            Console.WriteLine("Общее кол-во машин: " + res.TotalPassedCars);
            Console.WriteLine("Кол-во машин нарувшие скоростной режим: " + res.TotalSpeedViolatedCars);
            Console.WriteLine("Кол-во машин зафиксированных в угоне: " + res.CountOfStolenCars);

            void CarInfo(AVehicle car, string report)
            {
                Console.WriteLine(report + "\t" + car.ShowInfo());
            }
        }
    }
}
