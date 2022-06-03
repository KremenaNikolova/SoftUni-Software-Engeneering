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
            //double markers = markerCount * 7.20;

            Console.WriteLine(summMats - (summMats * discount/100));
        }
    }
}

//Ани трябва да купи определен брой пакетчета с химикали, пакетчета с маркери, както и
//препарат за почистване на дъска

//колко пари ще трябва да събере Ани, за да плати сметката

//Пакет химикали - 5.80 лв. 
//Пакет маркери - 7.20 лв. 
//Препарат - 1.20 лв (за литър)

//•	Брой пакети химикали - цяло число в интервала [0...100]
//•	Брой пакети маркери - цяло число в интервала [0...100]
//•	Литри препарат за почистване на дъска - цяло число в интервала [0…50]
//•	Процент намаление - цяло число в интервала [0...100]




