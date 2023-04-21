using System;

namespace _01.ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double evaluation = double.Parse(Console.ReadLine());

            if (evaluation >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
              
        }
    }
}
//да се напише конзолна програма, която чете оценка (дробно число), въведена от потребителя
//и отпечатва "Excellent!", ако оценката е 5.50 или по-висока.
