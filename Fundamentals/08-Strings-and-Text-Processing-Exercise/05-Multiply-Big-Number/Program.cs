using System;
using System.Text;

namespace _05_Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int multiply = int.Parse(Console.ReadLine());
            StringBuilder endProduct = new StringBuilder();
            StringBuilder reversed = new StringBuilder();

            int product = 0;
            int remainder = 0;

            if (input=="0" || multiply==0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = input.Length-1; i >=0 ; i--)
            {
                int intoNumber = int.Parse(input[i].ToString());
                product = multiply * intoNumber + remainder;
                remainder = product / 10;
                product %= 10;
                endProduct.Append(product);
            }

            if (remainder!=0)
            {
                endProduct.Append(remainder);
            }

            for (int i = endProduct.Length-1; i >= 0; i--)
            {
                reversed.Append(endProduct[i]);
            }

            Console.WriteLine(reversed);
            
        }
    }
}
