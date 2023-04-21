using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hiddenEggs = Console.ReadLine();
            string pattern = @"([@ | #]+[a-z]{3,}[@ | #]+)[^\w\d]*([/]+)[\d]+([/]+)";
            //"([@#]+[a-z]{3,}[@#]+)[^\w\d ]+([/]+)[\d]+([/]+)" - old wrong one

            List<List<string>> countEggs = new List<List<string>>();

            MatchCollection matches = Regex.Matches(hiddenEggs, pattern);

            foreach (Match match in matches)
            {
                string toStr = match.ToString();
                string eggsCount="";
                string eggsColor = "";
                for (int i = 0; i < toStr.Length; i++)
                {
                    if (char.IsDigit(toStr[i]))
                    {
                        eggsCount+=toStr[i];
                    }
                    if (char.IsLetter(toStr[i]))
                    {
                        eggsColor += toStr[i];
                    }
                }
                countEggs.Add( new List<string> { eggsColor, eggsCount });
            }
            foreach (var counter in countEggs)
            {
                if (int.Parse(counter[1])<=0)
                {
                    continue;
                }
                    Console.WriteLine($"You found {counter[1]} {counter[0]} eggs!");
            }
        }
    }
}
