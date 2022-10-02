using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Predicate_Party__1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            Action<List<string>> print = p => Console.WriteLine(string.Join(", ",p) + " are going to the party!");

            while (command!="Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                string condition = tokens[1];
                string index = tokens[2];

                if (action == "Remove")
                {
                    list.RemoveAll(Filter(condition, index));
                }
                else if (action == "Double")
                {
                    List<string> doublePeople = list.FindAll(Filter(condition, index));

                    int insertIndex = list.FindIndex(Filter(condition, index));

                    if (insertIndex>=0)
                    {
                        list.InsertRange(insertIndex, doublePeople);
                    }
                }

                command=Console.ReadLine();
            }

            if (list.Count>0)
            {
                print(list);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        static Predicate<string> Filter(string condition, string index)
        {
            switch (condition)
            {
                case "StartsWith":
                    return s=>s.StartsWith(index);
                case "EndsWith":
                    return s => s.EndsWith(index);
                case "Length":
                    return s => s.Length == int.Parse(index);
                default:
                    return default (Predicate<string>);
            }
        }
    }
}
