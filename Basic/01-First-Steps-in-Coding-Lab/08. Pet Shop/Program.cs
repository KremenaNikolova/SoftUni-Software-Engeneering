using System;

namespace FirstLab08012022
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFoodNumber = double.Parse(Console.ReadLine()); ;
            int catFoodNumber = int.Parse(Console.ReadLine());


            double lastPrice = (dogFoodNumber * 2.50) + (catFoodNumber * 4);

            Console.WriteLine($"{lastPrice} lv."); ;

        }
    }
}