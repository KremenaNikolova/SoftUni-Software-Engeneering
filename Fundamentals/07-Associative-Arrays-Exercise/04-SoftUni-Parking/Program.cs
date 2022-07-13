using System;
using System.Collections.Generic;

namespace _04_SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string username = input[1];
                string licensePlateNumber=string.Empty;
                if (input.Length>2)
                {
                    licensePlateNumber = input[2];
                }

                if (command == "register")
                {
                    if (!registeredUsers.ContainsKey(username))
                    {
                        registeredUsers.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!registeredUsers.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        registeredUsers.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
