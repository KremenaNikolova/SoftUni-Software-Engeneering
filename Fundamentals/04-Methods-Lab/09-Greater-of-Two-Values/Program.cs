using System;

namespace _09_Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            
            switch (type)
            {
                case "int":
                    int intOne = int.Parse(Console.ReadLine());
                    int intTwo = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(intOne, intTwo));
                    break;
                case "char":
                    char charOne = char.Parse(Console.ReadLine());
                    char charTwo = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(charOne, charTwo));
                    break;
                case "string":
                    string stringOne = Console.ReadLine();
                    string stringTwo = Console.ReadLine();
                    Console.WriteLine(GetMax(stringOne, stringTwo));
                    break;
                    
            }
        }

        static int GetMax(int intOne, int intTwo)
        {
            return Math.Max(intOne, intTwo);
        }

        static char GetMax(char charOne, char charTwo)
        {
            if (charOne > charTwo)
            {
                return charOne;
            }
            else
            {
                return charTwo;
            }
        }
        static string GetMax(string stringOne, string stringTwo)
        {
            int theBiggest = stringOne.CompareTo(stringTwo);
            if (theBiggest>0)
            {
                return stringOne;
            }
            else
            {
                return stringTwo;
            }
        }
        

    }
}
