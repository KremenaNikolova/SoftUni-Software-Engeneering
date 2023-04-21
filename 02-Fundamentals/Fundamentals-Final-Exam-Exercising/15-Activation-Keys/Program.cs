using System;

namespace _15_Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actiovationKey = Console.ReadLine();

            string[] command = Console.ReadLine().Split(">>>");
            while (command[0]!= "Generate")
            {
                string action = command[0];

                switch (action)
                {
                    case "Contains":
                        Contains(command[1], actiovationKey);
                        break;
                    case "Flip":
                        actiovationKey = Flip(command[1], int.Parse(command[2]), int.Parse(command[3]), actiovationKey);
                        break;
                    case "Slice":
                        actiovationKey = Slice(int.Parse(command[1]), int.Parse(command[2]), actiovationKey);
                        break;
                }

                command = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {actiovationKey}");
        }

        static void Contains(string substring, string actiovationKey)
        {
            if (actiovationKey.Contains(substring))
            {
                Console.WriteLine($"{actiovationKey} contains {substring}");
                return;
            }
            Console.WriteLine("Substring not found!");
        }

        static string Flip(string upperLower, int startIndex, int endIndex, string actiovationKey)
        {
            string upperOrLower = actiovationKey;
            upperOrLower = upperOrLower.Substring(startIndex, endIndex - startIndex);
            string originalSubstring = upperOrLower;
            if (upperLower == "Upper")
            {
                upperOrLower = upperOrLower.ToUpper();
                actiovationKey = actiovationKey.Replace(originalSubstring, upperOrLower);
                Console.WriteLine(actiovationKey);
                return actiovationKey;
            }
            upperOrLower = upperOrLower.ToLower();
            actiovationKey = actiovationKey.Replace(originalSubstring, upperOrLower);
            Console.WriteLine(actiovationKey);
            return actiovationKey;
            
        }

        static string Slice(int startIndex, int endIndex, string actiovationKey)
        {
            string substring = actiovationKey.Substring(startIndex, endIndex - startIndex);
            actiovationKey = actiovationKey.Replace(substring, "");
            Console.WriteLine(actiovationKey);
            return actiovationKey;
        }
    }
}
