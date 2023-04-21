using System;
using System.Linq;

namespace _04_Password_Validator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isSixToTenCharackters = SixToTenCharackters(password);
            bool isOnlyLettersAndDigits = OnlyLettersAndDigits(password);
            bool isAtLeastTwoDigits = AtLeastTwoDigits(password);



            if (isSixToTenCharackters == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (isOnlyLettersAndDigits == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (isAtLeastTwoDigits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isSixToTenCharackters == true && isOnlyLettersAndDigits == true && isAtLeastTwoDigits == true)
            {
                Console.WriteLine("Password is valid");
            }
        }


        static bool AtLeastTwoDigits(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }
            if (counter < 2)
            {
                return false;
            }
            return true;
        }

        static bool OnlyLettersAndDigits(string password)
        {
            foreach (char letterAndDigits in password)
            {
                if (!char.IsLetterOrDigit(letterAndDigits))
                {
                    return false;
                }

            }
            return true;
        }


        static bool SixToTenCharackters(this string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                counter++;
            }
            if (counter < 6 || counter > 10)
            {
                return false;
            }
            return true;
        }

    }
}
