﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
    abstract class AVehicle
    {
        protected int PassangerNumbers;
        protected int MaxSpeed;
        public string RegistrationNumb { get; }
        public int CurrentSpeed { get; }
        protected ColorCar colorcar;

        public AVehicle(int _PN, int _MSP, string _RN, int _CS, ColorCar _ColorCar)
        {
            PassangerNumbers = _PN;
            MaxSpeed = _MSP;
            RegistrationNumb = _RN;
            CurrentSpeed = _CS;
            colorcar = _ColorCar;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Скорость: {CurrentSpeed}, Регистрационный номер машины: {RegistrationNumb}");
        }

    }
}
