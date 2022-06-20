using System;
using System.Collections.Generic;

namespace _4_List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            List<string> output = new List<string>(input);

            for (int i = 0; i < input; i++)
            {
                //output[i] = Console.ReadLine();
                output.Add(Console.ReadLine());
            }
            for (int i = 0; i < output.Count; i++)
            {
                output.Sort();
                Console.WriteLine(i+1 + "." + output[i]);
            }
        }
    }
}
