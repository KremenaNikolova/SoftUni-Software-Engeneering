using System;

namespace _05SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isSpecialNumber = true;

            for (int i = 1; i <= number; i++)
            {
                int sum = 0;
                int currNumber = i;
                while (currNumber!=0)
                {
                    sum += currNumber % 10;
                    currNumber = currNumber / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecialNumber = true;
                    Console.WriteLine(i + " -> " + isSpecialNumber);
                }
                else
                {
                    isSpecialNumber = false;
                    Console.WriteLine(i + " -> " + isSpecialNumber);
                }
            }
        }
    }
}
