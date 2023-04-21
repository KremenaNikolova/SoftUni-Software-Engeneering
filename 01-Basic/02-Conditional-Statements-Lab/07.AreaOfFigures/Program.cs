using System;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
           

            if(figure == "square")
            {
                //•	Ако фигурата е квадрат (square): на следващия ред се чете едно дробно число - дължина на страната му

                double a = double.Parse(Console.ReadLine());
                double square = a * a;
                Console.WriteLine($"{square:f3}");
            }
            else if (figure == "rectangle")
            {
                //•	Ако фигурата е правоъгълник (rectangle): на следващите два реда четат две дробни числа - дължините на страните му
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double rectangle = a * b;
                Console.WriteLine($"{rectangle:f3}");

            }
            else if (figure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                double circle = Math.PI*a*a;
                Console.WriteLine($"{circle:f3}");

                //диаметър = 6;
                
                //обиколката = пи*6 = 2*пи*радиус;
                //лице = пи*2радус;

            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double triangle = (a * h) / 2;
                Console.WriteLine($"{triangle:f3}");
            }

        }
    }
}

//Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и
//пресмята лицето й. Фигурите са четири вида: квадрат (square), правоъгълник (rectangle),
//кръг (circle) и триъгълник (triangle). На първия ред на входа се чете вида на фигурата
//(текст със следните възможности: square, rectangle, circle или triangle). 
//•	Ако фигурата е кръг (circle): на следващия ред чете едно дробно число - радиусът на кръга
//•	Ако фигурата е триъгълник (triangle): на следващите два реда четат две дробни числа - дължината на страната му и дължината на височината към нея
//Резултатът да се закръгли до 3 цифри след десетичната запетая. 

