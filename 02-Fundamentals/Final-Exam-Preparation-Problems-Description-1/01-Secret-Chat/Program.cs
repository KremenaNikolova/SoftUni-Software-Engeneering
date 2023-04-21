using System;
using System.Linq;

namespace _01_Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] instrunctions = Console.ReadLine().Split(":|:");

            while (instrunctions[0] != "Reveal")
            {
                string command = instrunctions[0];
                //string action = instrunctions[1];

                switch (command)
                {
                    case "InsertSpace":
                        //Inserts a single space at the given index. The given index will always be valid.
                        int index = int.Parse(instrunctions[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        //If the message contains the given substring, cut it out, reverse it and add it at the end of the message. 
                        //If not, print "error".
                        //This operation should replace only the first occurrence of the given substring if there are two or more occurrences
                        string substring = instrunctions[1];
                        if (message.Contains(substring))
                        {
                            int indexOf = message.IndexOf(substring);
                            message = message.Remove(indexOf, substring.Length);
                            message = $"{message}{string.Join("", substring.Reverse())}";
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        //Changes all occurrences of the given substring with the replacement text
                        string haveToChange = instrunctions[1];
                        string replacement = instrunctions[2];

                        message = message.Replace(haveToChange, replacement);

                        Console.WriteLine(message);
                        break;
                }

                instrunctions = Console.ReadLine().Split(":|:");
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
