using System;

namespace _07_Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            //От конзолата се четат поредица от числа, всяко на отделен ред:
            //На първия ред – броя на групите от катерачи – цяло число в интервала[1...1000]
            int groups = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimandjaro = 0;
            double k2 = 0;
            double everest = 0;
            double allPeople = 0;

            for (int i = 1; i <= groups; i++)
            {
                //За всяка една група на отделен ред – броя на хората в групата – цяло число в интервала[1...1000]
                int peopleInGroup = int.Parse(Console.ReadLine());
                allPeople = allPeople + peopleInGroup;
                if (peopleInGroup <= 5)
                {
                    musala+=peopleInGroup;
                }
                else if (peopleInGroup>=6 && peopleInGroup <= 12)
                {
                    monblan+=peopleInGroup;
                }
                else if (peopleInGroup>=13 && peopleInGroup <= 25)
                {
                    kilimandjaro+=peopleInGroup;
                }
                else if (peopleInGroup>=26 && peopleInGroup <= 40)
                {
                    k2+=peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest+=peopleInGroup;
                }
            }
            musala = musala / allPeople * 100;
            monblan = monblan / allPeople * 100;
            kilimandjaro = kilimandjaro / allPeople * 100;
            k2 = k2 / allPeople * 100;
            everest = everest / allPeople * 100;

            Console.WriteLine($"{musala:f2}%");
            Console.WriteLine($"{monblan:f2}%");
            Console.WriteLine($"{kilimandjaro:f2}%");
            Console.WriteLine($"{k2:f2}%");
            Console.WriteLine($"{everest:f2}%");

        }
    }
}

//    •	Група до 5 човека – изкачват Мусала
//    •	Група от 6 до 12 човека – изкачват Монблан
//    •	Група от 13 до 25 човека – изкачват Килиманджаро
//    •	Група от 26 до 40 човека –  изкачват К2
//    •	Група от 41 или повече човека – изкачват Еверест
//    Да се напише програма, която изчислява процента на катерачите изкачващи всеки връх.

