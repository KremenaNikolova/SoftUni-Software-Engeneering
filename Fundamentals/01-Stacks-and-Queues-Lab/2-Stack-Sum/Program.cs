using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            string command = Console.ReadLine().ToLower();

            while (command !="end")
            {
                string[] token = command.Split();
                if (token[0] == "add")
                {
                    int firstNum = int.Parse(token[1]);
                    int secondNum = int.Parse(token[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else
                {
                    int countForRemove = int.Parse(token[1]);
                    if (stack.Count>countForRemove)
                    {
                        for (int i = 0; i < countForRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}
