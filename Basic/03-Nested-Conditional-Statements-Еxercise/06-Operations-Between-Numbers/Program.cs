using System;

namespace _06_Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //От конзолата се прочитат 3 реда, въведени от потребителя:
            //•	N1 – цяло число в интервала[0...40 000]
            double n1 = double.Parse(Console.ReadLine());
            //•	N2 – цяло число в интервала[0...40 000]
            double n2 = double.Parse(Console.ReadLine());
            //•	Оператор – един символ измежду: „+“, „-“, „*“, „/“, „%“
            string symbol = Console.ReadLine();
            double result = 0;
            string oddOrEven = "";
            //При събиране, изваждане и умножение на конзолата трябва да се отпечатат резултата и дали той е четен или нечетен.
            if(symbol=="+" || symbol == "-" || symbol == "*")
            {
                switch(symbol)
                {
                    case "+":
                    result = n1 + n2;
                        break;
                       case "-":
                    result = n1 - n2;
                        break;
                        case "*":
                    result = n1 * n2;
                        break;
                }                
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - odd");
                }
            }
            //При обикновеното деление – резултата.
            //При модулното деление – остатъка.
            else if (symbol == "/" || symbol == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else if (symbol == "/")
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} {symbol} {n2} = {result:f2}");
                }
                else if (symbol == "%")
                { 
                        result = n1 % n2;
                        Console.WriteLine($"{n1} {symbol} {n2} = {result}");
                }
                
            }


            //Трябва да се има предвид, че делителят може да е равен на 0(нула), а на нула не се дели. В този случай трябва да се отпечата специално съобщениe.

            

      

        }
    }
}
//•	Ако операцията е деление:
//o "{N1} / {N2} = {резултат}" – резултатът е форматиран до вторият знак след дес.запетая
//•	Ако операцията е модулно деление: 
//o "{N1} % {N2} = {остатък}"
//•	В случай на деление с 0 (нула): 
//o "Cannot divide {N1} by zero"
//