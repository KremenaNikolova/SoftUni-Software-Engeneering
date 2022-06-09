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

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length==1)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;
                for (int leftNumbers = i; leftNumbers > 0; leftNumbers--)  // 1 2 3 3 
                {
                    int currLeftElePosition = leftNumbers - 1;
                    if (currLeftElePosition > 0)
                    {
                        leftSum += numbers[currLeftElePosition];
                    }
                    
                }

                rightSum = 0;

                for (int rightNumbers = 0; rightNumbers < numbers.Length; rightNumbers++) //1 2 3 3
                {
                    int currRightElePosition = rightNumbers + 1;
                    if (currRightElePosition<numbers.Length-1)
                    {
                        rightSum += numbers[currRightElePosition];
                    }
                    
                }

                if (leftSum==rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
