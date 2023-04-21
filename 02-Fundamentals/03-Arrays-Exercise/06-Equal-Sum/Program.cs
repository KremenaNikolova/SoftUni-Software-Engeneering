using System;
using System.Linq;

namespace _06_Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;

            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum = 0;
                for (int leftToRight = 0; leftToRight < i; leftToRight++)
                {
                    leftSum += numbers[leftToRight];
                }

                rightSum = 0;
                for (int rightToLeft = numbers.Length-1; rightToLeft > i; rightToLeft--)
                {
                    rightSum += numbers[rightToLeft];
                }

                if (leftSum==rightSum && !isEqual)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
