//Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line.
//Use a function that accepts another function as one of its parameters.
//Start by building a regular function to hold the basic logic of the program.
//Something along the lines of Func<string, int, bool>.
//Afterward, create your main function which should accept the first function as one of its parameters.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isEqual = (name, input) => name.Sum(ch => ch) >= input;//true or false
            Func<string[], int, Func<string, int, bool>, string> check = (names, input, isEqual) => names.FirstOrDefault(name=>isEqual(name, input)); //return only the first name

            Console.WriteLine(check(names, input, isEqual));

        }
        
    }
}
