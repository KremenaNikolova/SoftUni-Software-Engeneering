using System;

namespace _01_Decrypting_Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0]!="Finish")
            {
                string action = command[0].Trim();
                switch (action)
                {
                    case "Replace":
                        text = Replace(command[1], command[2], text);
                        break;
                    case "Cut":
                        text= Cut(int.Parse(command[1]), int.Parse(command[2]), text);
                        break;
                    case "Make":
                        text = Make(command[1], text);
                        break;
                    case "Check":
                        Check(command[1], text);
                        break;
                    case "Sum":
                        Sum(int.Parse(command[1]), int.Parse(command[2]), text);
                        break;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static string Replace(string currChar, string newChar, string text)
        {
            text = text.Replace(currChar, newChar);
            Console.WriteLine(text);
            return text;
        }

        static string Cut(int startIndex, int endIndex, string text)
        {
            int lenght = (endIndex - startIndex) + 1;
            if (startIndex>=0 && endIndex<text.Length)
            {
                text = text.Remove(startIndex, lenght);
                Console.WriteLine(text);
                return text;
            }
            Console.WriteLine("Invalid indices!");
            return text;
        }

        static string Make(string upperOrLower, string text)
        {
            if (upperOrLower=="Upper")
            {
                text = text.ToUpper();
                Console.WriteLine(text);
                return text;
            }
            text = text.ToLower();
            Console.WriteLine(text);
            return text;
        }

        static void Check(string str, string text)
        {
            if (text.Contains(str))
            {
                Console.WriteLine($"Message contains {str}");
                return;
            }
            Console.WriteLine($"Message doesn't contain {str}");
        }

        static void Sum(int startIndex, int endIndex, string text)
        {
            int sumOfChars = 0;
            int lenght = (endIndex - startIndex) + 1;
            if (startIndex>=0 && endIndex<text.Length )
            {
                string substring = text.Substring(startIndex, lenght);
                for (int i = 0; i < substring.Length; i++)
                {
                    sumOfChars += substring[i];
                }
                Console.WriteLine(sumOfChars);
                return;
            }
            Console.WriteLine("Invalid indices!");
        }
    }
}
