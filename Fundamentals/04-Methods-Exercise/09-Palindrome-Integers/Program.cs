using System;

namespace _09_Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input!="END")
            {
                bool isPalindrome = PalindromeOrNot(input);
                Console.WriteLine(isPalindrome.ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        private static bool PalindromeOrNot(string input)
        {
            int inputToNumber = int.Parse(input);
            if (inputToNumber>=0 && inputToNumber<=9)
            {
                return true;
            }
            if (input[0]==input[input.Length-1])
            {
                return true;
            }
            return false;
        }
    }
}
