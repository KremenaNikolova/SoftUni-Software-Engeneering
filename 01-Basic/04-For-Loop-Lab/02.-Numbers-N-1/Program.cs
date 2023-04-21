using System;

namespace _02._Numbers_N_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; num--)
            {
                Console.WriteLine(num);
            }
        }
    }
}
