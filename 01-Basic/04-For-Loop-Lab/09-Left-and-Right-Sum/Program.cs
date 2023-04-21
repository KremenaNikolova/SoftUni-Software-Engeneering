using System;

namespace _09_Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbs = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < numbs; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum1 += num;
            }
            for (int i = 0; i < numbs; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                sum2 += num2;
            }
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1-sum2)}");
            }
        }
    }
}
