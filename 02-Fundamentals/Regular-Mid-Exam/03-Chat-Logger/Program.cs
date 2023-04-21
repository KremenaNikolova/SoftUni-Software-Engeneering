using System;
using System.Collections.Generic;

namespace _03_Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> message = new List<string>();
            bool isEnd = false;

            while (isEnd == false)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "end")
                {
                    isEnd = true;
                    Console.WriteLine();
                    break;
                }
                if (action == "Chat")
                {
                    message.Add(tokens[1]);
                }
                else if (action == "Delete")
                {
                    foreach (var letter in message)
                    {
                        if (letter == tokens[1])
                        {
                            message.Remove(letter);
                            break;
                        }
                    }
                }
                else if (action == "Edit")
                {
                    for (int i = 0; i < message.Count; i++)
                    {
                        if (message[i] == tokens[1])
                        {
                            message[i] = tokens[2];
                            break;
                        }
                    }
                }
                else if (action=="Pin")
                {
                    foreach (var item in message)
                    {
                        if (item == tokens[1])
                        {
                            message.Remove(item);
                            message.Add(item);
                            break;
                        }
                    }
                }
                else if (action == "Spam")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        message.Add(tokens[i]);
                    }
                }

            }

            foreach (var item in message)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
