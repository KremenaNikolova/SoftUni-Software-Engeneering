using System;

namespace _02_Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            

            while (number>0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;
                number=number / 10; 
            }

            Console.WriteLine(sum);
        }
    }
}
