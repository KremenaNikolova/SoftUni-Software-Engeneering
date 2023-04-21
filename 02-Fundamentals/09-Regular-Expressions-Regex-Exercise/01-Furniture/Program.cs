using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            string input = Console.ReadLine();
            List<string> names = new List<string>();
            double totalSpendMoney = 0;

            while (input!= "Purchase")
            {
                Match matchesNames = Regex.Match(input, regex);
                if (matchesNames.Success)
                {
                    string name = matchesNames.Groups["name"].ToString();
                    double price = double.Parse(matchesNames.Groups["price"].ToString());
                    int quantity = int.Parse(matchesNames.Groups["quantity"].ToString());
                    names.Add(name);
                    totalSpendMoney += price * quantity;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total money spend: {totalSpendMoney:f2}");
        }
    }
}
