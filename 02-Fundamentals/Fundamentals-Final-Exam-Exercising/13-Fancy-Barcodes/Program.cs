using System;
using System.Text.RegularExpressions;

namespace _13_Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodeCounter = int.Parse(Console.ReadLine());
            string pattern = @"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
           
            for (int i = 0; i < barcodeCounter; i++)
            {
                string barcodes = Console.ReadLine();
                Match validBarcode = Regex.Match(barcodes, pattern);
                string productGroup = string.Empty;
                if (!validBarcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    for (int j = 0; j < validBarcode.Length; j++)
                    {
                        string match = validBarcode.ToString();
                        char digit = char.Parse(match[j].ToString());
                        if (char.IsDigit(digit))
                        {
                            productGroup += digit;
                        }
                    }
                    if (productGroup==string.Empty)
                    {
                        Console.WriteLine("Product group: 00");
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
