using System;

namespace _03_New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            //напишете програма която да изчисли колко  ще им струва, да си засадят определен брой цветя и дали наличния бюджет ще им е достатъчен. 

            //цвете                  Роза    Далия    Лале    Нарцис     Гладиола
            //Цена на брой в лева     5       3.80    2.80      3          2.50

            //•	Ако Нели купи повече от 80 Рози - 10 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 90  Далии - 15 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 80 Лалета - 15 % отстъпка от крайната цена
            //•	Ако Нели купи по-малко от 120 Нарциса - цената се оскъпява с 15 %
            //•	Ако Нели Купи по-малко от 80 Гладиоли - цената се оскъпява с 20 %

            //•	Вид цветя -текст с възможности -"Roses", "Dahlias", "Tulips", "Narcissus", "Gladiolus"
            string flowers = Console.ReadLine();
            //•	Брой цветя -цяло число в интервала[10…1000]
            int numFlowers = int.Parse(Console.ReadLine());
            //•	Бюджет - цяло число в интервала[50…2500]
            int budged = int.Parse(Console.ReadLine());
            double cost = 0.0;

            switch (flowers)
            {
                case "Roses":
                    if (numFlowers <=80)
                    {
                        cost = 5 * numFlowers;
                    }
                    else
                    {
                        cost = (5 * numFlowers) - (5 * numFlowers)* 0.1;
                    }
                    break;
                case "Dahlias":
                    if (numFlowers <= 90)
                    {
                        cost = 3.80 * numFlowers;
                    }
                    else
                    {
                        cost = (3.80 * numFlowers) - (3.80 * numFlowers)* 0.15;
                    }
                    break;
                case "Tulips":
                    if (numFlowers <= 80)
                    {
                        cost = 2.80 * numFlowers;
                    }
                    else
                    {
                        cost = (2.80 * numFlowers) - (2.80 * numFlowers) * 0.15;
                    }
                    break;
                case "Narcissus":
                    if (numFlowers >= 120)
                    {
                        cost = 3 * numFlowers;
                    }
                    else
                    {
                        cost = (3 * numFlowers) + (3 * numFlowers)* 0.15;
                    }
                    break;
                case "Gladiolus":
                    if (numFlowers >= 80)
                    {
                        cost = 2.50 * numFlowers;
                    }
                    else
                    {
                        cost = (2.50 * numFlowers) + (2.50 * numFlowers)*0.2;
                    }
                    break;
            }
            double left = budged - cost;
            if (budged >= cost)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowers} and {left:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(left):f2} leva more.");
            }
        }
    }
}

//Да се отпечата на конзолата на един ред:
//•	Ако бюджета им е достатъчен - "Hey, you have a great garden with {броя цвета} {вид цветя} and {останалата сума} leva //left."
//•	Ако бюджета им е НЕ достатъчен - "Not enough money, you need {нужната сума} leva more."
//Сумата да бъде форматирана до втория знак след десетичната запетая.
