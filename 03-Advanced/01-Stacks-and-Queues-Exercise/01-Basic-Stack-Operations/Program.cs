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

            Stack<int> stack = new Stack<int>();
            int[] numsForPush = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int push = input[0];
            int pop = input[1];
            int numberCheck = input[2];
            int smallerNum = numsForPush[0];

            for (int i = 0; i < push; i++)
            {
                stack.Push(numsForPush[i]);
            }
            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }
            if (stack.Count==0)
            {
                Console.WriteLine("0");
                return;
            }
            while (stack.Count>0)
            {
                int currNum = stack.Pop();
                if (currNum == numberCheck)
                {
                    Console.WriteLine("true");
                    return;
                }
                else if (currNum<smallerNum)
                {
                    smallerNum = currNum;
                }
                
            }
            Console.WriteLine(smallerNum);


        }
    }
}
