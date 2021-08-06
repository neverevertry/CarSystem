using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
    public class Reporter
    {
        public int CarCount { get; set; }
        public int CargoCount { get; set; }
        public int BusCount { get; set; }
        public int CountOfStolenCars { get; set; }

        public int TotalPassedCars { get; set; }
        public int TotalSpeedViolatedCars { get; set; }
    }
}
