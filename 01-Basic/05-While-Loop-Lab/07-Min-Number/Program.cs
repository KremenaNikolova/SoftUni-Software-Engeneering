using System;

namespace _06_Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int number = 0;
            int smallestNumber = int.MaxValue;

            while (num != "Stop")
            {
                number = int.Parse(num);
                if (number < smallestNumber)
                {
                    smallestNumber = number;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(smallestNumber);
        }


    }
}
