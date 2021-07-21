using System;
using System.Collections.Generic;
using System.Linq;

namespace Регистрация_машин
{
    class CarCheckingSystem
    {
        private List<AVehicle> carList = new List<AVehicle>();
        private List<string> NumStolenCars = new List<string>(); 
        private Reporter reporter = new Reporter();
        public Action<AVehicle, string> CH;
       
        private void MonitorInfo(AVehicle transoprt)
        {
            if (transoprt is Car)
            {
                string ReportPassangerCar = "Легковая машина";
                reporter.CarCount++;
                CH.Invoke(transoprt, ReportPassangerCar);
            }
            if (transoprt is Cargo)
            {
                string ReportCargoCar = "Грузовая машина";
                reporter.CargoCount++;
                CH.Invoke(transoprt, ReportCargoCar);
            }
            if (transoprt is Bus)
            {
                string ReportBus = "Автобус";
                reporter.BusCount++;
                CH.Invoke(transoprt, ReportBus);
            }
        }

        private Reporter GetReport()
        {
            reporter.TotalPassedCars = reporter.CarCount + reporter.BusCount + reporter.CargoCount;
            reporter.TotalSpeedViolatedCars = carList.Count();
            return reporter;
        }

        private void Excess(AVehicle transoprt)
        {
            if (transoprt.CurrentSpeed > 110)
            {
                carList.Add(transoprt);
                string ReportSpeed = "Превышение скорости";
                CH.Invoke(transoprt, ReportSpeed);
            }
        }

        private void CheckStolenCar(AVehicle car)
        {
            if (NumStolenCars.Contains(car.RegistrationNumb))
            {
                string InterceptionReport = "Перехват";
                CH.Invoke(car, InterceptionReport);
                reporter.CountOfStolenCars++;
            }
        }

        public void StartSystem(CarCheckingSystem ccs)
        {
            AVehicle avh = RandomVehicleGenerator.GenerateRandomVehicle();
            ccs.MonitorInfo(avh);
            ccs.Excess(avh);
            ccs.CheckStolenCar(avh);
        }

        public Reporter StopSystem(CarCheckingSystem ccs)
        {
            return ccs.GetReport();
        }
    }
}
