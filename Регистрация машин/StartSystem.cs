using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
    class StartSystem
    {
        private CarCheckingSystem ccs = new CarCheckingSystem();
        private RandomVehicleGenerator rand = new RandomVehicleGenerator();

        public void StartCheckSys()
        {
            AVehicle avh = rand.GenerateRandomVehicle();
            ccs.MonitorInfo(avh);
            ccs.Excess(avh);
            ccs.CheckStolenCar(avh);
        }
        public void StopSystem()
        {
            ccs.MonitorShowIntuder();
            ccs.InfoAboutAllCar();
        }
    }
}
