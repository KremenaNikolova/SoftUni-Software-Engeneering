using System;
using System.Collections.Generic;

namespace _4_Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i]==')')
                {
                    int index = stack.Pop();
                    string forPrint = input.Substring(index, i - index + 1);
                    Console.WriteLine(forPrint);
                }
            }
        }
    }
}
