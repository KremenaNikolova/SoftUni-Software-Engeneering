using System;

namespace _10_Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            int sum = 0;
            int sum2 = 0;

            for (int i = 0; i < nums; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sum = sum + num;
                }
                else
                {
                    sum2 = sum2 + num;
                }
            }
            if (sum == sum2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum-sum2)}");
            }
        }
    }
}
