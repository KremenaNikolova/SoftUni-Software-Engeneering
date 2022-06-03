using System;

namespace _09_Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney=double.Parse(Console.ReadLine());
            int countOfStudents=int.Parse(Console.ReadLine());
            double priceOfLighsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            //double allCostLighsabers = countOfStudents * priceOfLighsaber+(priceOfLighsaber*(countOfStudents*0.1));
            double allCostLighsabers = countOfStudents + (countOfStudents * 0.1);
            allCostLighsabers = Math.Ceiling(allCostLighsabers) * priceOfLighsaber;
            //allCostLighsabers += allCostLighsabers * 0.1;
            double allCostRobes = countOfStudents * priceOfRobe;
            double freeBelts = countOfStudents / 6;
            double allCostBelt = priceOfBelt * countOfStudents - priceOfBelt * Math.Floor(freeBelts);
            //allCostLighsabers *= priceOfBelt;

            double allCost = allCostLighsabers + allCostRobes + allCostBelt;

            if (amountOfMoney>=allCost)
            {
                Console.WriteLine($"The money is enough - it would cost {allCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {allCost-amountOfMoney:f2}lv more.");
            }
        }
    }
}
