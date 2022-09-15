using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray(); //always are 3 numbers
            // first number is number of elements to push
            // secpnd number is number of elements to pop
            // third number is the number we should look for in the stack

            Queue<int> stack = new Queue<int>();
            int[] numsForEnqueue = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int Enqueue = input[0];
            int Dequeue = input[1];
            int numberCheck = input[2];
            int smallerNum = numsForEnqueue[0];

            for (int i = 0; i < Enqueue; i++)
            {
                stack.Enqueue(numsForEnqueue[i]);
            }
            for (int i = 0; i < Dequeue; i++)
            {
                stack.Dequeue();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            while (stack.Count > 0)
            {
                int currNum = stack.Dequeue();
                if (currNum == numberCheck)
                {
                    Console.WriteLine("true");
                    return;
                }
                else if (currNum < smallerNum)
                {
                    smallerNum = currNum;
                }

            }
            Console.WriteLine(smallerNum);


        }
    }
}
