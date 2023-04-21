using System;

namespace _12_Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string[] command = Console.ReadLine().Split(" ");

            while (command[0]!= "Done")
            {
                string action = command[0];
                switch (action)
                {
                    case "TakeOdd":
                        password = TakeOdd(password);
                        break;
                    case "Cut":
                        password = Cut(int.Parse(command[1]), int.Parse(command[2]), password);
                        break;
                    case "Substitute":
                        password = Substitute(command[1], command[2], password);
                        break;
                }

                command = Console.ReadLine().Split(" ");
            }
            Console.WriteLine($"Your password is: {password}");
        }

         static string TakeOdd(string password)
        {
            string newpassword = string.Empty;
            for (int i = 1; i < password.Length; i++)
            {
                if (i%2!=0)
                {
                    newpassword+= password[i];
                }
            }
            password = newpassword;
            Console.WriteLine(password);
            return password;
        }

        static string Cut(int index, int length, string password)
        {
            string substring = password.Substring(index, length);
            int indexOfSubstring = password.IndexOf(substring);
            password = password.Remove(indexOfSubstring, substring.Length);
            Console.WriteLine(password);
            return password;
        }

        static string Substitute(string substring, string substitute, string password)
        {
            if (password.Contains(substring))
            {
                password=password.Replace(substring, substitute);
                Console.WriteLine(password);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
            return password;
        }
    }
}
