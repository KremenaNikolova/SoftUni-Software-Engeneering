using System;

namespace _12RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            int sum = 0;
            
            for (int i = 1; i <= countOfNumbers; i++)
            {
                bool isSpecialNum = false;
                int currNumber = i;
                while (currNumber > 0)
                {
                    sum += currNumber % 10;
                    currNumber = currNumber / 10;
                }
                if (isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11)) ;
                {
                    Console.WriteLine("{0} -> {1}", i, isSpecialNum);
                }
                
                sum = 0;
            }

        }
    }
}
