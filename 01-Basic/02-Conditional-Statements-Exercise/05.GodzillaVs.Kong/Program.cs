using System;

namespace _05.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ред 1.Бюджет за филма – реално число в интервала[1.00 … 1000000.00]
            double budged = double.Parse(Console.ReadLine());
            //Ред 2.Брой на статистите – цяло число в интервала[1 … 500]
            int statists = int.Parse(Console.ReadLine());
            //Ред 3.Цена за облекло на един статист – реално число в интервала[1.00 … 1000.00]
            double perClothe = double.Parse(Console.ReadLine());
            double allClothes = statists * perClothe;

            //•	Декорът за филма е на стойност 10% от бюджета. 
            double decor = budged * 0.1;
            double endCost = 0;

            //•	При повече от 150 статиста, има отстъпка за облеклото на стойност 10%.
            if (statists > 150)
            {
                double discount = allClothes - (allClothes * 0.1);
                endCost = decor + discount;
            }
            else
            {
                endCost = decor + allClothes;
            }
            if (endCost > budged)
            {
                double difference = endCost - budged;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(difference):f2} leva more.");
            }
            else if(endCost<=budged)
            {
                double leftMoney = budged - endCost;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftMoney:f2} leva left.");
            }

        }
    }
}
//която да изчисли, дали предвидените средства са достатъчни за снимането на филма. 

//На конзолата трябва да се отпечатат два реда:
//•	Ако парите за декора и дрехите са повече от бюджета:
//"Not enough money!"
//"Wingard needs {парите недостигащи за филма} leva more."
//•	Ако парите за декора и дрехите са по малко или равни на бюджета:
//"Action!"
//"Wingard starts filming with {останалите пари} leva left."

//Резултатът трябва да е форматиран до втория знак след десетичната запетая.

