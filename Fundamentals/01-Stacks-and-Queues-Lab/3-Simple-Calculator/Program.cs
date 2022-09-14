using System;
using System.Collections.Generic;

namespace _3_Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                counter++;
                stack.Push(input[i]);
                if (counter == 3)
                {
                    counter = 1;
                    int firstNum = int.Parse(stack.Pop());
                    char charr = char.Parse(stack.Pop());
                    int secondNum = int.Parse(stack.Pop());
                    int sum = 0;
                    if (charr == '+')
                    {
                        sum = firstNum + secondNum;
                    }
                    else
                    {
                        sum = secondNum - firstNum;
                    }
                    //string theNum = sum.ToString();
                    stack.Push(sum.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
