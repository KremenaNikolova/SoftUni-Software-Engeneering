using System;

namespace _09._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Дължина в см – цяло число в интервала[10 … 500]
            //2.Широчина в см – цяло число в интервала[10 … 300]
            //3.Височина в см – цяло число в интервала[10… 200]
            //4.Процент  – реално число в интервала[0.000 … 100.000]

            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double vollume = lenght * width * height;
            double liters = vollume / 1000;
            double endLiters = liters * (1 - percent / 100);
            //нужни литри: 299.625 * (1 - 0.17) = 248.68875 литра

            Console.WriteLine(endLiters);

        }
    }
}

//аквариум с формата на паралелепипед v = a*b*c

//Трябва да се пресметне колко литра вода ще събира аквариума, ако се знае,
//че определен процент от вместимостта му е заета от пясък, растения, нагревател и помпа. 

//Да се напише програма, която изчислява литрите вода, която са необходими за напълването на аквариума.