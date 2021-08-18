using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VehicleRegistrator.Bussines
{
    public class CarCheckingSystem
    {
        private List<AVehicle> carList = new List<AVehicle>();
        private List<string> NumStolenCars = new List<string>(); 
        private Reporter reporter = new Reporter();
        public event Action<AVehicle, string> HandlerInfoCar;
       
        public void MonitorInfo(AVehicle transoprt)
        {
            if (transoprt is Car)
            {
                string ReportPassangerCar = "Легковая машина";
                reporter.CarCount++;
                HandlerInfoCar.Invoke(transoprt, ReportPassangerCar);
            }
            if (transoprt is Cargo)
            {
                string ReportCargoCar = "Грузовая машина";
                reporter.CargoCount++;
                HandlerInfoCar.Invoke(transoprt, ReportCargoCar);
            }
            if (transoprt is Bus)
            {
                string ReportBus = "Автобус";
                reporter.BusCount++;
                HandlerInfoCar.Invoke(transoprt, ReportBus);
            }
        }

        public Reporter GetReport()
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
                HandlerInfoCar.Invoke(transoprt, ReportSpeed);
            }
        }

        public void ImportNumberStoleCars(IReadToListAvehicle rtla)
        {
            NumStolenCars = rtla.ReadToListAvehicle();
        }

        private void CheckStolenCar(AVehicle car)
        {
            if (NumStolenCars.Contains(car.RegistrationNumb))
            {
                string InterceptionReport = "Перехват";
                HandlerInfoCar.Invoke(car, InterceptionReport);
                reporter.CountOfStolenCars++;
            }
        }

        public void StartSystem()
        {
             AVehicle avh = RandomVehicleGenerator.GenerateRandomVehicle();
             MonitorInfo(avh);
             Excess(avh);
             CheckStolenCar(avh);
        }

        public Reporter StopSystem()
        {
            return GetReport();
        }
    }
}
