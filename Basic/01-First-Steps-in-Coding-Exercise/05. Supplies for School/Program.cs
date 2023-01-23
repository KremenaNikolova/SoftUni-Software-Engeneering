using System;

namespace _05._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pensCount = int.Parse(Console.ReadLine());
            int markerCount = int.Parse(Console.ReadLine());
            int chemistryCount = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            double summMats = (pensCount * 5.80) + (markerCount * 7.20) + (chemistryCount * 1.20);

            Console.WriteLine(summMats - (summMats * discount/100));
        }
    }
}




