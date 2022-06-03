using System;

namespace _06_Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int number = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int numberCopy = number;
            int sum = 0;

            //int counter = 1;
            //int firstNumForFacturial = 1;

            while (number > 0)
            {
                int factorials = 1;
                int currentNumber = number % 10;
                number = number / 10;
                for (int i = 2; i <= currentNumber; i++)
                {
                    //int pretendSum = i * counter;
                    factorials *= i;
                    //pretendSum = 0;
                    //counter++;
                    //Console.WriteLine(factorials);
                }
                sum += factorials;


            }
            Console.WriteLine(sum == numberCopy ? "yes" : "no");

        }
    }
}
