using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05_Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|\|{1})([A-Za-z ]+)\1(\d{2}\/\d{2}\/\d{2})\1([0-9]{1,4}|10000)\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<Food> foodInformation = new List<Food>();
            int totalCallories = 0;

            foreach (var match in matches)
            {
                string[] splitedInfromation = match.ToString().Split(new char[] { '#', '|' }, StringSplitOptions.RemoveEmptyEntries); //#Bread(0)#19/03/21(1)#4000(2)#|
                int callories = int.Parse(splitedInfromation[2]);
                totalCallories += callories;
                var food = new Food(splitedInfromation[0], splitedInfromation[1], int.Parse(splitedInfromation[2]));
                foodInformation.Add(food);
            }

            int days = totalCallories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (var food in foodInformation)
            {
                Console.WriteLine($"Item: {food.FoodName}, Best before: {food.BestBefore}, Nutrition: {food.Calories}");
            }
        }
        class Food
        {
            public Food(string foodName, string bestBefore, int calories)
            {
                this.FoodName = foodName;
                this.BestBefore = bestBefore;
                this.Calories = calories;

            }

            public string FoodName { get; set; }
            public string BestBefore { get; set; }
            public int Calories { get; set; }

        }

    }
}
