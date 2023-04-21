using System;

namespace _01_Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actiovationKey = Console.ReadLine();
            string[] instrictions = Console.ReadLine().Split(">>>");

            while (instrictions[0] != "Generate")
            {
                string cmd = instrictions[0];
                if (cmd== "Contains")
                {
                    string substring = instrictions[1];
                    if (actiovationKey.Contains(substring))
                    {
                        Console.WriteLine($"{actiovationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (cmd == "Flip")
                {
                    string upperOrLower = instrictions[1];
                    int startIndex = int.Parse(instrictions[2]);
                    int endIndex = int.Parse(instrictions[3]);

                    string originalKey = actiovationKey.Substring(startIndex, endIndex - startIndex);
                    string newKey = originalKey.ToLower();
                    if (upperOrLower=="Upper")
                    {
                        newKey = newKey.ToUpper();
                    }
                    actiovationKey=actiovationKey.Replace(originalKey, newKey);
                    Console.WriteLine(actiovationKey);
                }
                else if (cmd=="Slice")
                {
                    int startIndex = int.Parse(instrictions[1]);
                    int endIndex = int.Parse(instrictions[2]);

                    string originalKey = actiovationKey.Substring(startIndex, endIndex - startIndex);
                    actiovationKey = actiovationKey.Replace(originalKey, "");
                    Console.WriteLine(actiovationKey);
                }
                instrictions = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {actiovationKey}");
        }
    }
}
