//Create a generic class Box that can be initialized with any type and store the value.
//Override the ToString() method and print the type and stored value.

using System;
using System.Collections.Generic;

namespace _01_Generic_Box_of_String
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                box.CollectingElements.Add(Console.ReadLine());
            }

            Console.WriteLine(box);
        }
    }
}
