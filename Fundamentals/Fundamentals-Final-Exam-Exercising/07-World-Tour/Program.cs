using System;

namespace _07_World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travel = Console.ReadLine();

            string[] command = Console.ReadLine().Split(":");

            while (command[0] != "Travel")
            {
                string action = command[0];
                switch (action)
                {
                    case "Add Stop":
                        travel = AddStop(int.Parse(command[1]), command[2], travel);
                        break;
                    case "Remove Stop":
                        travel = RemoveStop(int.Parse(command[1]), int.Parse(command[2]), travel);
                        break;
                    case "Switch":
                        travel = Switch(command[1], command[2], travel);
                        break;
                }
                Console.WriteLine(travel);
                command = Console.ReadLine().Split(":");
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travel}");
        }

        static string AddStop(int index, string str, string travel)
        {
            if (travel.Length > index)
            {
                travel = travel.Insert(index, str);
            }
            return travel;
        }

        static string RemoveStop(int startIndex, int endIndex, string travel)
        {
            if (travel.Length > endIndex && startIndex > -1)
            {
                travel = travel.Remove(startIndex, endIndex-startIndex+1);
            }

            return travel;
        }

        static string Switch(string oldString, string newString, string travel)
        {
            if (travel.Contains(oldString))
            {
                travel = travel.Replace(oldString, newString);
            }
            return travel;
        }
    }
}
