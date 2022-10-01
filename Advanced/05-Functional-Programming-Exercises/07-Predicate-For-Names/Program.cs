//Write a program that filters a list of names according to their length.
//On the first line, you will be given an integer n, representing a name's length.
//On the second line, you will be given some names as strings separated by space.
//Write a function that prints only the names whose length is less than or equal to n.

using System;
using System.Collections.Generic;

namespace _07_Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> listNames = new List<string>();

            //Func<string[], int, List<string>> avalibleNames = (name, lenth) =>
            //{
            //    for (int i = 0; i < name.Length; i++)
            //    {
            //        if (name[i].Length <=lenth)
            //        {
            //            listNames.Add(name[i]);
            //        }
            //    }
            //    return listNames;
            //};

            //avalibleNames(names, nameLength);

            Predicate<string> predicate = x => x.Length<=nameLength;
            for (int i = 0; i < names.Length; i++)
            {
                if (predicate(names[i]))
                {
                    listNames.Add(names[i]);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,listNames));
        }
    }
}
