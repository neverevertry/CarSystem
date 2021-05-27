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
        private int CarCount = 0;
        private int CargoCount = 0;
        private int BusCount = 0;
        private int StolenCarsCount = 0;

        public void MonitorInfo(AVehicle transoprt)
        {
            transoprt.ShowInfo();
            if (transoprt is Car)
            {
                Console.WriteLine("Тип машины: Легковая машина");
                Console.WriteLine();
                CarCount++;
            }
            if (transoprt is Cargo)
            {
                Console.WriteLine("Тип машины: Грузовая машина");
                Console.WriteLine();
                CargoCount++;
            }
            if (transoprt is Bus)
            {
                Console.WriteLine("Тип машины: Автобус");
                Console.WriteLine();
                BusCount++;
            }
        }

        public void InfoAboutAllCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Кол-во легковых автомобилей: " + CarCount);
            Console.WriteLine("Кол-во грузовых автомобилей: " + CargoCount);
            Console.WriteLine("Кол-во автобусов: " + BusCount);
            Console.WriteLine("Общее кол-во машин: " + (CarCount + CargoCount + BusCount));
            Console.WriteLine("Кол-во машин нарувшие скоростной режим: " + carList.Count());
            Console.WriteLine("Кол-во машин зафиксированных в угоне: " + StolenCarsCount);
        }

        public void Excess(AVehicle transoprt)
        {
            if (transoprt.GetSpeed() > 110)
            {
                carList.Add(transoprt);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Превышение скорости!");
                Console.ResetColor();
            }
        }

        public void CheckStolenCar(AVehicle car)
        {
            if (NumStolenCars.Contains(car.GetNumb()))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Перехват!");
                Console.ResetColor();
                StolenCarsCount++;
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
