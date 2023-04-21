using System;

namespace _04_Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numbers = 1;

            while (num>=numbers)
            {
                Console.WriteLine(numbers);
                numbers = numbers * 2 + 1;
            }
        }
    }
}
