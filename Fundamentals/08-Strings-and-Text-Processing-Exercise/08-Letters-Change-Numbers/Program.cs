using System;

namespace _08_Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. We have number between two letters
            //2.First, you start with the letter before the number. 
            
            //3.Then you move to the letter after the number
            
            

            //Write a program that calculates the sum of all numbers after the operations on each number have been done.

            //Example: "A12b s17G"
            //

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (var item in input)
            {
                char firstLetter = item[0];
                char lastLetter = item[item.Length - 1];

                double number = double.Parse(item.Substring(1, item.Length-2));

                //  - If it's uppercase you divide the number by the letter's position in the alphabet. 
                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    double letterPositionInAlphabet = firstLetter - 64;
                    sum += number / letterPositionInAlphabet;
                }
                //  - If it's lowercase you multiply the number with the letter's position in the alphabet. 
                else if(firstLetter >= 97 && firstLetter <= 122)
                {
                    double letterPositionInAlphabet = firstLetter - 96;
                    sum += number * letterPositionInAlphabet;
                }
                //  - If it's uppercase you subtract its position from the resulted number.
                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    double letterPositionInAlphabet = lastLetter - 64;
                    sum = sum-letterPositionInAlphabet;
                }
                //  - If it's lowercase you add its position to the resulted number.
                else if (lastLetter >= 97 && lastLetter <= 122)
                {
                    double letterPositionInAlphabet = lastLetter - 96;
                    sum += letterPositionInAlphabet;
                }
                
            }

            Console.WriteLine($"{sum:f2}");
            


        }
    }
}
