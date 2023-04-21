using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            int numberOfOperation = int.Parse(Console.ReadLine());
            Stack<string> previousOperation = new Stack<string>();
            previousOperation.Push(String.Empty);

            for (int i = 0; i < numberOfOperation; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                if (action == "1")
                {
                    text = text.Append(command[1]);
                    previousOperation.Push(text.ToString());
                }
                else if (action=="2")
                {
                    text = text.Remove(text.Length- int.Parse(command[1]), int.Parse(command[1]));
                    previousOperation.Push(text.ToString());
                }
                else if (action=="3")
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (action=="4")
                {
                    previousOperation.Pop();
                    text = new StringBuilder(previousOperation.Peek());
                }
            }

        }
    }
}
