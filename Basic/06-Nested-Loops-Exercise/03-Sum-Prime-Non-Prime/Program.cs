using System;

namespace _03_Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int num;
            int sumPrime = 0;
            int sumnonPrime = 0;
                     

            while (number != "stop")
               
            {
                num = int.Parse(number);
                
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    number = Console.ReadLine();
                    continue;
                }
                bool isPrime = true;
                for (int i = 2; i < num-1; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;                                       
                        break;
                    }
                }
                if (isPrime)
                {
                    sumPrime += num;
                }
                else
                {
                    sumnonPrime += num;
                }

                number = Console.ReadLine();
               
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumnonPrime}");

        }
    }
}
