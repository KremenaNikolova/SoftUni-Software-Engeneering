using System;

namespace _02_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != password)
            {
                input = Console.ReadLine();
            }

            if (input == password)
            {
                Console.WriteLine($"Welcome {name}!");
            }
                
        }
    }
}
