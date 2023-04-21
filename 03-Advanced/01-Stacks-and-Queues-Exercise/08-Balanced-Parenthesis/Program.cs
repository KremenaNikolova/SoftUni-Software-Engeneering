using System;
using System.Collections.Generic;

namespace _08_Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool isBalancedParentheses = true;

            foreach (var parenthese in input)
            {
                if (parenthese=='{' || parenthese=='[' || parenthese == '(')
                {
                    parentheses.Push(parenthese);
                    continue;
                }
                else if (parentheses.Count == 0)
                {
                    isBalancedParentheses = false;
                    break;
                }
                else if (parentheses.Peek()=='{' && parenthese == '}')
                {
                    parentheses.Pop();
                }
                else if (parentheses.Peek() == '[' && parenthese == ']')
                {
                    parentheses.Pop();
                }
                else if (parentheses.Peek() == '(' && parenthese == ')')
                {
                    parentheses.Pop();
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
