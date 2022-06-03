using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Рекордът в секунди – реално число в интервала[0.00 … 100000.00]
            double record = double.Parse(Console.ReadLine()); //55555.67
            //2.Разстоянието в метри – реално число в интервала[0.00 … 100000.00]
            double meters = double.Parse(Console.ReadLine()); //3017
            //3.Времето в секунди, за което плува разстояние от 1 м. - реално число в интервала[0.00 … 1000.00]
            double timePerMeter = double.Parse(Console.ReadLine()); //5.03

            double swimSpeed = meters * timePerMeter; //tr.prepluv=3017*5.03
            double beforeSlow = Math.Floor(meters / 15);
            double slow = beforeSlow * 12.5; //zabavqne = (3017/15)*12.5
            double endSeconds = swimSpeed + slow; //kraino vreme = (3017*5.03) + zabavqneto

            //На всеки 15 м.към времето му се добавят 12.5 сек.: 
            //1500 / 15 = 100 * 12.5 = 1250 сек. (meters/15)*12.5

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

//	Ако Иван е подобрил Световния рекорд (времето му е по-малко от рекорда) отпечатваме:
//   " Yes, he succeeded! The new world record is {времето на Иван} seconds."
//	Ако НЕ е подобрил рекорда (времето му е по-голямо или равно на рекорда) отпечатваме:
//   "No, he failed! He was {недостигащите секунди} seconds slower."
// Pезултатът трябва да се форматира до втория знак след десетичната запетая.

//Да се напише програма, която изчислява дали се е справил със задачата, като се има предвид, че:
//съпротивлението на водата го забавя на всеки 15 м. с 12.5 секунди.

//Да се изчисли времето в секунди, за което Иванчо ще преплува разстоянието и разликата спрямо
//Световния рекорд. 

