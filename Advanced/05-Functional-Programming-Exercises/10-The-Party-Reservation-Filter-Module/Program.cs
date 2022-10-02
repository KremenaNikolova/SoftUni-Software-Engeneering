//You need to implement a filtering module to a party reservation software.
//First, the Party Reservation Filter Module (PRFM for short) has been passed a list with invitations.
//Next, the PRFM receives a sequence of commands that specify whether you need to add or remove a given filter.
//Each PRFM command is in the given format:
//"{command;filter type;filter parameter}"
//You can receive the following PRFM commands: 
//•	"Add filter"
//•	"Remove filter"
//•	"Print"
//The possible PRFM filter types are: 
//•	"Starts with"
//•	"Ends with"
//•	"Length"
//•	"Contains"
//All PRFM filter parameters will be a string (or an integer only for the "Length" filter).
//Each command will be valid e.g. you won't be asked to remove a non-existent filter.
//The input will end with a "Print" command, after which you should print all the party-goers that are left after the filtration.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            Action<List<string>> print = p => Console.WriteLine(string.Join(" ", p));

            string command = Console.ReadLine();



            while (command != "Print")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string condition = tokens[1];
                string index = tokens[2];

                if (action == "Add filter")
                {
                    filters.Add(condition + index, Filter(condition, index));
                }
                else
                {
                    filters.Remove(condition + index);
                }

                command = Console.ReadLine();
            }

            foreach (var action in filters)
            {
                list.RemoveAll(action.Value);
            }

            if (list.Count > 0)
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
                case "Starts with":
                    return s => s.StartsWith(index);
                case "Ends with":
                    return s => s.EndsWith(index);
                case "Length":
                    return s => s.Length == int.Parse(index);
                case "Contains":
                    return s => s.Contains(index);
                default:
                    return default;
            }
        }
    }
}

