using System;

namespace _02_Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int number=int.Parse(Console.ReadLine());
                sum += number;
                if (number > max)
                {
                    max = number;
                }
            }
            if ((sum-max) == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs((sum-max)-max)}");
            }
        }
    }
}
