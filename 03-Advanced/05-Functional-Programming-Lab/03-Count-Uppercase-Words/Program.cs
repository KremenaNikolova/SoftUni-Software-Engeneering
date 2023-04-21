//Create a program that reads a line of text from the console. Print all the words that start with an uppercase letter in the same
//order you've received them in the text.

using System;
using System.Linq;

namespace _03_Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = x => char.IsUpper(x[0]);

            Console.WriteLine(String.Join(Environment.NewLine, Array.FindAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),isUpper)));

            
        }
    }
}
