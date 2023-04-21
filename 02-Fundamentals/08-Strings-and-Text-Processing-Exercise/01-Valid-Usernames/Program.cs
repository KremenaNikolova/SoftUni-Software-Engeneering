using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsername = new List<string>();

            foreach (var username in usernames)
            {
                bool isValid = true;

                if (username.Length >= 3 && username.Length <= 16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        char letterOrDigit = username[i];
                        if (!(char.IsLetterOrDigit(letterOrDigit) || letterOrDigit == '-' || letterOrDigit == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid == true)
                    {
                        validUsername.Add(username);
                    }
                }
                
            }

            Console.WriteLine(String.Join(Environment.NewLine, validUsername));
        }
    }
}
