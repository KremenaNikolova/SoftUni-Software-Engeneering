using System;
using System.Text;

namespace _07_String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int bombNumberPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currCharr = input[i];
                if (currCharr=='>')
                {
                    bombNumberPower += int.Parse(input[i + 1].ToString());
                    result.Append(currCharr);
                }
                else if (bombNumberPower == 0)
                {
                    result.Append(currCharr);
                }
                else
                {
                    bombNumberPower--;
                }

            }

            Console.WriteLine(result);
        }
    }
}
