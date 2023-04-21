using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countForCommand = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countForCommand; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0]==2)
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }
                }
                else if (command[0]==3 && stack.Count>0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command[0]==4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            if (stack.Count>0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
