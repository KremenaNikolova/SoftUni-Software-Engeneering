using System;
using System.Linq;

namespace _01_Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] instructions = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (instructions[0] != "Reveal")
            {
                string action = instructions[0];

                switch (action)
                {
                    case "InsertSpace":
                        message = InsertSpace(int.Parse(instructions[1]), message);
                        break;
                    case "Reverse":
                        message = Reverse(instructions[1], message);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(instructions[1], instructions[2], message);
                        break;
                }
                instructions = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }

        static string InsertSpace(int index, string message)
        {
            message = message.Insert(index, " ");
            Console.WriteLine(message);
            return message;
        }

        static string Reverse(string substring, string message)
        {
            //string originalMessage = message;
            //if (message.Contains(substring))
            //{
            //    int index = message.IndexOf(substring);
            //    originalMessage = message.Substring(index, substring.Length);
            //    char[] toCharr = originalMessage.ToCharArray();
            //    Array.Reverse(toCharr);
            //    originalMessage = string.Join("", toCharr);
            //    message = message.Substring(0, index);
            //    message = message + originalMessage;
            //
            //    Console.WriteLine(message);
            //    return message;
            //}
            if (message.Contains(substring))
            {
                int index = message.IndexOf(substring);
                message = message.Remove(index, substring.Length);
                message = $"{message}{string.Join("", substring.Reverse())}";
                Console.WriteLine(message);
                return message;
            }

            Console.WriteLine("error");
            return message;

        }

        static string ChangeAll(string substring, string replacement, string message)
        {
            message = message.Replace(substring, replacement);
            Console.WriteLine(message);
            return message;
        }
    }
}
