using System;

namespace _03_New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budged = int.Parse(Console.ReadLine());
            double cost = 0.0;

            switch (flowers)
            {
                case "Roses":
                    cost = numFlowers <= 80 ?
                        5 * numFlowers :
                        (5 * numFlowers) - (5 * numFlowers) * 0.1;
                    break;
                case "Dahlias":
                    cost = numFlowers <= 90 ?
                        3.80 * numFlowers :
                        (3.80 * numFlowers) - (3.80 * numFlowers) * 0.15;
                    break;
                case "Tulips":
                    cost = numFlowers <= 80 ?
                        2.80 * numFlowers :
                        (2.80 * numFlowers) - (2.80 * numFlowers) * 0.15;
                    break;

                case "Narcissus":
                    cost = numFlowers >= 120 ?
                        3 * numFlowers :
                        (3 * numFlowers) + (3 * numFlowers) * 0.15;
                    break;

                case "Gladiolus":
                    cost = numFlowers >= 80 ?
                        2.50 * numFlowers :
                        (2.50 * numFlowers) + (2.50 * numFlowers) * 0.2;
                    break;
            }
            double left = budged - cost;

            if (budged >= cost)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowers} and {left:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(left):f2} leva more.");
            }
        }
    }
}
