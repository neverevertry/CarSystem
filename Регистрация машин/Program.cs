using System;
using System.Collections.Generic;
using System.Linq;

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
            foreach(var car in carList)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                car.ShowInfo();
            }
        }
    }

    abstract class AVehicle
    {
        protected int PassangerNumbers;
        protected int MaxSpeed;
        protected string RegistrationNumb;
        protected int CurrentSpeed;
        protected ColorCar colorcar;

        public AVehicle(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar)
        {
            PassangerNumbers = _PN;
            MaxSpeed = _MSP;
            RegistrationNumb = _RN;
            CurrentSpeed = _CS;
            colorcar = _ColorCar;
        }

        public abstract int GetSpeed();
        public abstract void ShowInfo();
        public abstract string GetNumb();
    }

    class Car : AVehicle
    {
        public Car(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar) : base(_PN, _MSP, _RN, _CS, _ColorCar) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Скорость: {CurrentSpeed}, Регистрационный номер машины: {RegistrationNumb}");
        }

        public override int GetSpeed()
        {
            return CurrentSpeed;
        }

        public override string GetNumb()
        {
            return RegistrationNumb;
        }
    }

    class Bus : AVehicle
    {
        public Bus(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar) : base(_PN, _MSP, _RN, _CS, _ColorCar) { }
        public override void ShowInfo()
        {
            Console.WriteLine($"Скорость: {CurrentSpeed}, Регистрационный номер машины: {RegistrationNumb}");
        }

        public override int GetSpeed()
        {
            return CurrentSpeed;
        }

        public override string GetNumb()
        {
            return RegistrationNumb;
        }
    }

    class Cargo : AVehicle
    {
        public Cargo(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar) : base(_PN, _MSP, _RN, _CS, _ColorCar) { }
        public override void ShowInfo()
        {
            Console.WriteLine($"Скорость: {CurrentSpeed}, Регистрационный номер машины: {RegistrationNumb}");
        }

        public override int GetSpeed()
        {
            return CurrentSpeed;
        }

        public override string GetNumb()
        {
            return RegistrationNumb;
        }
    }

    enum ColorCar { Blue, Red, White, Yellow, Black };
    class RandomValuesForMachine
    {
        private string RandomRegisterNumb;
        private int CurrentSpeed;
        private Random random;

        public RandomValuesForMachine()
        {
            RandomRegisterNumb = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            random = new Random();
        }

        public AVehicle GetRandomVehicle()
        {
            string RegNumb = "";

            RegNumb += RandomRegisterNumb[random.Next(0, 25)];
            for (int i = 0; i < 3; i++)
                RegNumb += RandomRegisterNumb[random.Next(26, 34)];
            RegNumb += RandomRegisterNumb[random.Next(0, 25)];
            RegNumb += RandomRegisterNumb[random.Next(0, 25)];
            CurrentSpeed = random.Next(70, 150);


            int enumSize = Enum.GetNames(typeof(ColorCar)).Length;
            ColorCar randomColor = (ColorCar)random.Next(0, enumSize);

            AVehicle[] avh = new AVehicle[3];
            avh[0] = new Car(random.Next(0, 3), 150, RegNumb, CurrentSpeed, randomColor);
            avh[1] = new Bus(random.Next(0, 15), 110, RegNumb, CurrentSpeed, randomColor);
            avh[2] = new Cargo(random.Next(0, 2), 100, RegNumb, CurrentSpeed, randomColor);

            if (CurrentSpeed >= 111)
                return avh[0];
            if (CurrentSpeed >= 70 && CurrentSpeed < 80)
                return avh[2];

            return avh[random.Next(0, 2)];
        }

    }
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
