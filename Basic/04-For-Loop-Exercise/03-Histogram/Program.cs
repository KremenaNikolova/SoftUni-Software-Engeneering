using System;

namespace _03_Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int numbersTwo = 0;
            double numberP1 = 0;
            double numberP2 = 0;
            double numberP3 = 0;
            double numberP4 = 0;
            double numberP5 = 0;

            for (int i = 1; i <= numbers; i++)
            {
                numbersTwo = int.Parse(Console.ReadLine());

                if (numbersTwo <= 199)
                {
                    numberP1=numberP1+1;
                }
                else if (numbersTwo >=200 && numbersTwo <= 399)
                {
                    numberP2=numberP2+1;
                }
                else if (numbersTwo>=400 && numbersTwo <= 599)
                {
                    numberP3=numberP3+1;
                }
                else if (numbersTwo>=600 && numbersTwo <= 799)
                {
                    numberP4=numberP4+1;
                }
                else if (numbersTwo >= 800)
                {
                    numberP5=numberP5+1;
                }
            }
            double percentP1 = numberP1 / numbers * 100;
            double percentP2 = numberP2 / numbers * 100;
            double percentP3 = numberP3 / numbers * 100;
            double percentP4 = numberP4 / numbers * 100;
            double percentP5 = numberP5 / numbers * 100;

            Console.WriteLine($"{percentP1:f2}%");
            Console.WriteLine($"{percentP2:f2}%");
            Console.WriteLine($"{percentP3:f2}%");
            Console.WriteLine($"{percentP4:f2}%");
            Console.WriteLine($"{percentP5:f2}%");


        }
    }
}
