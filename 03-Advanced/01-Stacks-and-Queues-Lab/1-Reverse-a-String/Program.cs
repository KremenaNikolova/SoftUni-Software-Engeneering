using System;
using System.Collections;
using System.Collections.Generic;

namespace _1_Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> str = new Stack<char>();
            string reversedWord = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char charr = input[i];
                str.Push(charr);
            }
            while (str.Count>0)
            {
                reversedWord+=str.Pop();
            }

            Console.WriteLine(reversedWord);
        }
    }
}
