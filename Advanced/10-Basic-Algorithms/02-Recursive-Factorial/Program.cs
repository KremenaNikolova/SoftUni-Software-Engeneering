using System;

namespace _02_Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        static int Factorial(int number)
        {
            if (number==0)
            {
                return 1;
            }
            return number*Factorial(number-1);
        }
    }
}
