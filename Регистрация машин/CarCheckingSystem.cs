using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Регистрация_машин
{
    class CarCheckingSystem
    {
        private List<AVehicle> carList = new List<AVehicle>();
        private List<string> NumStolenCars = new List<string>();
        public Reporter reporter = new Reporter();

        public void MonitorInfo(AVehicle transoprt)
        {
            transoprt.ShowInfo();
            if (transoprt is Car)
            {
                Console.WriteLine("Тип машины: Легковая машина");
                Console.WriteLine();
                reporter.CarCount++;
            }
            if (transoprt is Cargo)
            {
                Console.WriteLine("Тип машины: Грузовая машина");
                Console.WriteLine();
                reporter.CargoCount++;
            }
            if (transoprt is Bus)
            {
                Console.WriteLine("Тип машины: Автобус");
                Console.WriteLine();
                reporter.BusCount++;
            }
        }

        public Reporter GetReport()
        {
            reporter.TotalPassedCars = reporter.CarCount + reporter.BusCount + reporter.CargoCount;
            reporter.TotalSpeedViolatedCars = carList.Count();
            return reporter;
        }

        public void Excess(AVehicle transoprt)
        {
            if (transoprt.CurrentSpeed > 110)
            {
                carList.Add(transoprt);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Превышение скорости!");
                Console.ResetColor();
            }
        }

        public void CheckStolenCar(AVehicle car)
        {
            if (NumStolenCars.Contains(car.RegistrationNumb))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Перехват!");
                Console.ResetColor();
                reporter.CountOfStolenCars++;
            }
        }
        public void MonitorShowIntuder()
        {
            foreach (var car in carList)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                car.ShowInfo();
                Console.ResetColor();
            }
        }
    }
}
