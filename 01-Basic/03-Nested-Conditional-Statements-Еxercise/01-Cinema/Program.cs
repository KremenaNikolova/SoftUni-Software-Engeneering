using System;

namespace _01_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double income = 0.0;
            //изчислява общите приходи от билети при пълна зала. Резултатът да се отпечата във формат като в примерите по-долу, с 2 знака след десетичната точка
            //•	Premiere – премиерна прожекция, на цена 12.00 лева.
            //•	Normal – стандартна прожекция, на цена 7.50 лева.
            //•	Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.

            if (projection == "Premiere")
            {
                income = row * column * 12;
            }
            else if (projection == "Normal")
            {
                income = row * column * 7.50;
            }
            else if(projection == "Discount")
            {
                income = row * column * 5.00;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
