using System;

namespace _07_Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordForRepeat = Console.ReadLine();
            int timesForRepeat = int.Parse(Console.ReadLine());

            Repeater(wordForRepeat, timesForRepeat);
        }

        static void Repeater(string wordForRepeat, int timesForRepeat)
        {
            for (int i = 0; i < timesForRepeat; i++)
            {
                Console.Write(wordForRepeat);
            }
        }
    }
}
