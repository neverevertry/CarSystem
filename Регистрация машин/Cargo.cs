using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
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
}
