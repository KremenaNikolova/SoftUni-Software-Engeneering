using System;

namespace _04_Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashMashine = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            int numToys = 0;
            double saved = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    saved += i * 5 - 1;
                }
                if (i % 2 != 0)
                {
                    numToys++;
                }
            }
            double soldToys = numToys * priceToy;
            saved += soldToys;
            double end = saved - priceWashMashine;

            if (saved >= priceWashMashine)
            {
                Console.WriteLine($"Yes! {end:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(end):f2}");
            }
        }
    }
}
