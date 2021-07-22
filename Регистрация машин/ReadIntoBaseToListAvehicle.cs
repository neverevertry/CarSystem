using System;
using System.IO;

namespace Регистрация_машин
{
    class ReadIntoBaseToListAvehicle
    {
        public void ReadIntoBaseToListHijackedCar(CarCheckingSystem ccs)
        {
            Console.WriteLine("Укажите путь к файлу");
            string path = Console.ReadLine();
            try
            {
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ccs.NumStolenCars.Add(line);
                }
                Console.WriteLine("Successful import");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Not found file");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
