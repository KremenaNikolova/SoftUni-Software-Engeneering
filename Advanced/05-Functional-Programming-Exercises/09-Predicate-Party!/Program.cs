//Ivan 's parents are on a vacation for the holidays and he is planning an epic party at home.
//Unfortunately, his organizational skills are next to non-existent, so you are given the task to help him with the reservations.
//On the first line, you receive a list of all the people that are coming. On the next lines, until you get the "Party!" command, you may be asked to double or remove all the people that apply to the given criteria.
//There are three different criteria: 
//•	Everyone that has his name starting with a given string
//•	Everyone that has a name ending with a given string
//•	Everyone that has a name with a given length
//Finally, print all the guests who are going to the party separated by ", " and then add the ending "are going to the party!".
//If no guests are going to the party print "Nobody is going to the party!"

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] incomingPeople = Console.ReadLine().Split();
            string command = Console.ReadLine();
            List<string> partyPeople = new List<string>(incomingPeople);

            Func<List<string>, string, string, List<string>> StartWith = (person, index, cmd) =>
            {
                List<string> list = new List<string>(partyPeople);
                if (cmd == "Double")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.StartsWith(index))
                        {
                            list.Add(human);
                        }

                    }
                }
                else if (cmd == "Remove")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.StartsWith(index))
                        {
                            if (list.Contains(human))
                            {
                                list.Remove(human);
                            }
                        }
                    }
                }

                return partyPeople = new List<string>(list);
            };
            Func<List<string>, string, string, List<string>> EndWith = (person, index, cmd) =>
            {
                List<string> list = new List<string>(partyPeople);
                if (cmd == "Double")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.EndsWith(index))
                        {
                            list.Add(human);
                        }

                    }
                }
                else if (cmd == "Remove")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.EndsWith(index))
                        {
                            if (list.Contains(human))
                            {
                                list.Remove(human);
                            }
                        }
                    }
                }

                return partyPeople = new List<string>(list);
            };
            Func<List<string>, int, string, List<string>> Length = (person, index, cmd) =>
            {
                List<string> list = new List<string>(partyPeople);
                if (cmd == "Double")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.Length == index)
                        {
                            list.Add(human);
                        }

                    }
                }
                else if (cmd == "Remove")
                {
                    foreach (var human in partyPeople)
                    {
                        if (human.Length == index)
                        {
                            if (list.Contains(human))
                            {
                                list.Remove(human);
                            }
                        }
                    }
                }

                return partyPeople = new List<string>(list);
            };

            Action<List<string>> print = p => Console.WriteLine($"{string.Join(", ", p.OrderBy(p => p).ToArray())} are going to the party!");

            while (command != "Party!")
            {
                string[] tokens = command.Split(' ');
                string cmd = tokens[0];
                string action = tokens[1];
                string index = tokens[2];

                switch (action)
                {
                    case "StartsWith":
                        StartWith(partyPeople, index, cmd);
                        break;
                    case "EndsWith":
                        EndWith(partyPeople, index, cmd);
                        break;
                    case "Length":
                        Length(partyPeople, int.Parse(index), cmd);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();

            }

            if (partyPeople.Count > 0)
            {
                print(partyPeople);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}
