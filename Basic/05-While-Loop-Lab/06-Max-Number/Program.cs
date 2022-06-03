using System;

namespace _06_Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int number = 0;
            int biggestNumber = int.MinValue;

            while (num!="Stop")
            {
                number = int.Parse(num);
                if (number > biggestNumber)
                {
                    biggestNumber = number;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(biggestNumber);
        }
        

    }
}
