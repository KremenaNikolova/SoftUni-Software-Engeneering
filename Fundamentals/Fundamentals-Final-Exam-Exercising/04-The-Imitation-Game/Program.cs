using System;

namespace _04_The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] command = Console.ReadLine().Split("|");
            while (command[0]!= "Decode")
            {
                string action = command[0];

                switch (action)
                {
                    case "Move":
                        message = Move(int.Parse(command[1]), message);
                        break;
                    case "Insert":
                        message = Insert(int.Parse(command[1]), command[2], message);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(command[1], command[2], message);
                        break;
                }

                command = Console.ReadLine().Split("|");
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string Move(int numberOfLetters, string message)
        {
            string originalMessage = message;
            originalMessage = message.Substring(numberOfLetters);
            message = message.Remove(numberOfLetters);
            message = originalMessage+ message;
            //Console.WriteLine(message);
            return message;

        }

        static string Insert(int index, string value, string message)
        {
            message = message.Insert(index, value);
           // Console.WriteLine(message);
            return message;
        }

        private static string ChangeAll(string substring, string replacement, string message)
        {
            message = message.Replace(substring, replacement);
            //Console.WriteLine(message);
            return message;
        }
    }
}
