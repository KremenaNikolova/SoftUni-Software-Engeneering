using System;

namespace _07_Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimandjaro = 0;
            double k2 = 0;
            double everest = 0;
            double allPeople = 0;

            for (int i = 1; i <= groups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                allPeople = allPeople + peopleInGroup;
                if (peopleInGroup <= 5)
                {
                    musala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monblan += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest += peopleInGroup;
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

