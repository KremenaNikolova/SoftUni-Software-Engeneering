using System;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int counter = 0;

            int lenght;
            lenght = username.Length - 1;
            while (lenght >= 0)
            {
                password = password + username[lenght];
                lenght--;
            }

            string enterThePassword = Console.ReadLine();

            while (enterThePassword != password)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                enterThePassword = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in.");


        }
    }
}