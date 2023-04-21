using System;

namespace _07_Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum+=num;
            }
            Console.WriteLine(sum);
        }
    }
}
