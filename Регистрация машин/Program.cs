using System;
using System.Collections.Generic;
using System.Linq;

namespace Регистрация_машин
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSystem ss = new StartSystem();
            ConsoleKeyInfo input;
            Console.WriteLine("1.Press 1 to start 2 to exit");

            do
            {
                input = Console.ReadKey();
                ss.StartCheckSys();

            } while (input.Key!=ConsoleKey.NumPad2);

            ss.StopSystem();
        }
    }
}
