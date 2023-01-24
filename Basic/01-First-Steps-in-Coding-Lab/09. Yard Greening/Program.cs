using System;

namespace _01._2_PB_CSharp_First_Steps_in_Coding_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());

            double allPrice = meters * 7.61; 
            double discount = allPrice * 18 / 100;
            double finalPrice = allPrice - discount;


            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}