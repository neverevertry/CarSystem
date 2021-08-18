using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRegistrator.Bussines
{
    public class Cargo : AVehicle
    {
        public Cargo(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar) : base(_PN, _MSP, _RN, _CS, _ColorCar) { }
    }
}
