using System;
using System.Text.RegularExpressions;

namespace _02_Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"@#+[A-Z][a-zA-Z\d]{4,}[A-Z]@#+";

            int barcodeCount = int.Parse(Console.ReadLine());
           

            for (int i = 0; i < barcodeCount; i++)
            {
                string barcodes = Console.ReadLine();
                Match match = Regex.Match(barcodes, barcodePattern);
                string check = match.ToString();
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string productGroup = string.Empty;
                    for (int j = 0; j < check.Length; j++)
                    {
                        char digit = check[j];
                        if (char.IsDigit(digit))
                        {
                            productGroup += digit;
                        }
                    }
                    if (productGroup.Length<=0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }

            }
        }
    }
}
