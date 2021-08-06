using System;
namespace Регистрация_машин
{
    public static class RandomVehicleGenerator
    {
        private const string AvailableValuesForRegNumber = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        static public AVehicle GenerateRandomVehicle()
        {
            Random random = new Random();
            int CurrentSpeed = random.Next(70, 150);
            string RegNumb = "";

            RegNumb += AvailableValuesForRegNumber[random.Next(0, 25)];
            for (int i = 0; i < 3; i++)
                RegNumb += AvailableValuesForRegNumber[random.Next(26, 34)];
            RegNumb += AvailableValuesForRegNumber[random.Next(0, 25)];
            RegNumb += AvailableValuesForRegNumber[random.Next(0, 25)];


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
