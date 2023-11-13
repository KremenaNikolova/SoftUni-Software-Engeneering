using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double swimSpeed = meters * timePerMeter;
            double beforeSlow = Math.Floor(meters / 15);
            double slow = beforeSlow * 12.5;
            double endSeconds = swimSpeed + slow;

            if (record > endSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {endSeconds:f2} seconds.");
            }
            else
            {
                double notEnough = record - endSeconds;
                Console.WriteLine($"No, he failed! He was {Math.Abs(notEnough):f2} seconds slower.");
            }



        }
    }
}

