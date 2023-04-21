using System;
using System.Text.RegularExpressions;

namespace _03_SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+(\.\d+)?)\$";
            string input = Console.ReadLine();
            double income = 0;

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, regex);
                if (match.Success)
                {
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = quantity * price;
                    Console.WriteLine($"{match.Groups["name"]}: {match.Groups["product"]} - {totalPrice:f2}");
                    income += totalPrice;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
