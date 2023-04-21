using System;

namespace _08_Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            int sumMax = int.MinValue;
            int sumMin = int.MaxValue;

            for (int counter = 0; counter < numberInput; counter++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > sumMax)
                {
                    sumMax = num;                
                }
                if (num < sumMin)
                {
                    sumMin = num;
                }
            }
            Console.WriteLine($"Max number: {sumMax}");
            Console.WriteLine($"Min number: {sumMin}");
        }
    }
}
