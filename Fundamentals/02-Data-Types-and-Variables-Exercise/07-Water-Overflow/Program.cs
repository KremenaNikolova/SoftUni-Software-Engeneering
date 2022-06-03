using System;

namespace _07_Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY_OF_TANK = 255;
            int numberOfLine = int.Parse(Console.ReadLine());
            int fillingTheTank = 0;

            for (int i = 0; i < numberOfLine; i++)
            {
                int literOfWaterForPour = int.Parse(Console.ReadLine());
                
                fillingTheTank += literOfWaterForPour;
                if (CAPACITY_OF_TANK<fillingTheTank)
                {
                    Console.WriteLine("Insufficient capacity!");
                    fillingTheTank -= literOfWaterForPour;
                }
            }
            Console.WriteLine(fillingTheTank);

        }
    }
}
