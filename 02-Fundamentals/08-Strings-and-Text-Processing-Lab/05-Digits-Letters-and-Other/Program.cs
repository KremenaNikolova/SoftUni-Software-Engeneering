using System;
using System.Linq;
using System.Text;

namespace _05_Digits_Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder isDigit=new StringBuilder();
            StringBuilder isLetter = new StringBuilder();
            StringBuilder isOther = new StringBuilder();


            foreach (var charr in input)
            {
                if (char.IsDigit(charr))
                {
                   isDigit.Append(charr);
                }
                else if (char.IsLetter(charr))
                {
                    isLetter.Append(charr);
                }
                else
                {
                    isOther.Append(charr);
                }
            }

            Console.WriteLine(isDigit);
            Console.WriteLine(isLetter);
            Console.WriteLine(isOther);

            
        }
    }
}
