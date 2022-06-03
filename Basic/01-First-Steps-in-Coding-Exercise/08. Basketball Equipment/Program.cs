using System;

namespace _08._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Годишната такса за тренировки по баскетбол – цяло число в интервала[0… 9999]
            int tax = int.Parse(Console.ReadLine());
            double shoes = tax - (tax * 0.4);
            double clothes = shoes - (shoes * 0.2);
            double ball = clothes * 1 / 4;
            double accessories = ball * 1 / 5;
            double endPrice = tax + shoes + clothes + ball + accessories;

            Console.WriteLine(endPrice);

        }
    }
}

//Напишете програма, която изчислява какви разходи ще има Джеси,
//ако започне да тренира, като знаете колко е таксата за тренировки по баскетбол
//за период от 1 година. 

//•	Баскетболни кецове – цената им е 40% по-малка от таксата за една година
//•	Баскетболен екип – цената му е 20% по-евтина от тази на кецовете
//•	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
//•	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка
