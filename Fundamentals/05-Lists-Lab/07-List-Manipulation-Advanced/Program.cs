using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isEnd = false;
            bool isChanged = false;

            while (isEnd == false)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    isEnd = true;
                    break;
                }
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int addNumber = int.Parse(tokens[1]);
                        input.Add(addNumber);
                        isChanged = true;
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(tokens[1]);
                        input.Remove(removeNumber);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        int removeAtIndex = int.Parse(tokens[1]);
                        input.RemoveAt(removeAtIndex);
                        isChanged = true;
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(tokens[1]);
                        int indexOfTheNumber = int.Parse(tokens[2]);
                        input.Insert(indexOfTheNumber, insertNumber);
                        isChanged = true;
                        break;
                    case "Contains":
                        int containNumber = int.Parse(tokens[1]);
                        input.Contains(containNumber);
                        if (input.Contains(containNumber)==true)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        PrintEvenNumbers(input);
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(input);
                        break;
                    case "GetSum":
                        SumAllNumbers(input);
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        int number = int.Parse(tokens[2]);
                        PrintFulfillConditionNumbers(input, condition, number);
                        break;
                }
                
            }
            if (isChanged == true)
            {
                Console.WriteLine(string.Join(" ", input));
            }


        }

        private static void PrintFulfillConditionNumbers(List<int> input, string condition, int number)
        {
            if (condition==">")
            {
                List<int> copyOfInput = new List<int>(input);
                copyOfInput.RemoveAll(copyOfInput => copyOfInput <= number);
                Console.WriteLine(string.Join(" ", copyOfInput));

            }
            else if (condition == ">=")
            {
                List<int> copyOfInput = new List<int>(input);
                copyOfInput.RemoveAll(copyOfInput => copyOfInput < number);
                Console.WriteLine(string.Join(" ", copyOfInput));
            }
            else if (condition == "<")
            {
                List<int> copyOfInput = new List<int>(input);
                copyOfInput.RemoveAll(copyOfInput => copyOfInput >= number);
                Console.WriteLine(string.Join(" ", copyOfInput));
            }
            else if (condition == "<=")
            {
                List<int> copyOfInput = new List<int>(input);
                copyOfInput.RemoveAll(copyOfInput => copyOfInput > number);
                Console.WriteLine(string.Join(" ", copyOfInput));
            }
            //Console.WriteLine();
        }

        private static void SumAllNumbers(List<int> input)
        {
            int sum = 0;
            foreach (var number in input)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }

        private static void PrintOddNumbers(List<int> input)
        {
            foreach (var number in input)
            {
                if (number % 2 != 0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintEvenNumbers(List<int> input)
        {
            foreach (var number in input)
            {
                if (number%2==0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
