using System;
using System.Collections.Generic;

namespace _08_Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<char> parentheses = new Queue<char>();
            bool isBalancedParentheses = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    parentheses.Enqueue(input[i]);
                }
                else if(input[i] == ' ')
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            if (input.Length% parentheses.Count!=0)
            {
                isBalancedParentheses = false;
            }
            for (int h = input.Length - 1; h >= 0; h--)
            {
                if (parentheses.Count == 0 || isBalancedParentheses == false)
                {
                    break;
                }
                if (input[h] == '}' && parentheses.Peek() == '{')
                {
                    parentheses.Dequeue();
                }
                else if (input[h] == ')' && parentheses.Peek() == '(')
                {
                    parentheses.Dequeue();
                }
                else if (input[h] == ']' && parentheses.Peek() == '[')
                {
                    parentheses.Dequeue();
                }
                else if (input[h] == ' ' && parentheses.Peek() == ' ')
                {
                    parentheses.Dequeue();
                }
                else
                {
                    isBalancedParentheses = false;
                }
                
            }
            if (isBalancedParentheses == false || parentheses.Count>0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }



        }
    }
}
