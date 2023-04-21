using System;

namespace _04_Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo =int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = numOne; i <= numTwo; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine("Sum: " + sum);
        }
    }
}
