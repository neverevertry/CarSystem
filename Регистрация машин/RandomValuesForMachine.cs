using System;
using System.Collections.Generic;
using System.Text;

namespace Регистрация_машин
{
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
}
