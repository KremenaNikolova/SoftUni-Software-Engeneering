using System;

namespace _04_Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            //Възрастта на Лили - цяло число в интервала[1...77]
            int age = int.Parse(Console.ReadLine()); //10
            //Цената на пералнята - число в интервала[1.00...10 000.00]
            double priceWashMashine = double.Parse(Console.ReadLine()); //170
            //Единична цена на играчка -цяло число в интервала[0...40]
            int priceToy = int.Parse(Console.ReadLine()); //6
            double money = 0;
            int numToys = 0;
            double moneyBirthday = 10;
            double saved = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    saved+= i * 5 - 1;

                    //poluchava pari +10lv za vseki cheten rojden den
                    //45
                    //lili e spestqvala parite
                    //bratyt na lili vzima po 1 lv na vseki 10lv
                }
                if (i % 2 != 0)
                {
                    numToys ++; //5
                    //poluchava igrachki
                }
            }
            double soldToys = numToys * priceToy; //30
            saved= saved + soldToys; //75
            double end = saved - priceWashMashine;
            //lili dobavq prodadenite igrachki i gi sybira s ostanalite pari
            //sys sybranite pari iska da si kupi peralnqta

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
