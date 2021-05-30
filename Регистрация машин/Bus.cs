using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
    class Bus : AVehicle
    {
        public Bus(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar) : base(_PN, _MSP, _RN, _CS, _ColorCar) { }
    }
}
