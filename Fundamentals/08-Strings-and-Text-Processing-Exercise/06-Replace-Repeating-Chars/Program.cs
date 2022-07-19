using System;
using System.Text;

namespace _06_Replace_Repeating_Chars
{
    internal class Program
    {
        public static object StringBuild { get; private set; }

        static void Main(string[] args)
        {
            string simpleString = Console.ReadLine();
            StringBuilder correctedString = new StringBuilder();

            for (int i = 0; i < simpleString.Length-1; i++)
            {
                if (simpleString[i] == simpleString[i+1])
                {
                    continue;
                }
                else
                {
                    correctedString.Append(simpleString[i]);
                }
                //a a a a a b b b b b c  d  d  d  e  e  e  e  d  s  s  a  a
                //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22
            }

            correctedString.Append(simpleString[simpleString.Length - 1]);

            Console.WriteLine(correctedString);
        }
    }
}
