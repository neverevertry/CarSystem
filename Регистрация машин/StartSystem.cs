using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
    class StartSystem
    {
        public CarCheckingSystem ccs = new CarCheckingSystem();
        private RandomVehicleGenerator rand = new RandomVehicleGenerator();

        public void StartCheckSys()
        {
            AVehicle avh = rand.GenerateRandomVehicle();
            ccs.MonitorInfo(avh);
            ccs.Excess(avh);
            ccs.CheckStolenCar(avh);
        }
        public Reporter StopSystem()
        {
            ccs.MonitorShowIntuder();
            return ccs.GetReport();
        }
    }
}
