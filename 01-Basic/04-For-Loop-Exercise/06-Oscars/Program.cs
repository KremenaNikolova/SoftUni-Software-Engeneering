using System;

namespace _06_Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());

            for (int i = 1; i <= jury; i++)
            {
                string nextName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                double points2 = (nextName.Length * juryPoints) / 2;
                points += points2;
                if (points >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:f1}!");
                    break;
                }
            }

            if (points < 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - points:f1} more!");
            }

        }
    }
}
