//Create a program that helps you decide what clothes to wear from your wardrobe. You will receive the clothes, which are currently in your wardrobe, sorted by their color in the following format:
//"{color} -> {item1},{item2},{item3}…"
//If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records. You can also receive repeating items for a certain color and you have to keep their count.
//In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a space in the following format:
//"{color} {clothing}"
//"{color} clothes:
//* { item1}
//- { count}
//* { item2}
//- { count}
//* { item3}
//- { count}
//…
//* { itemN}
//- { count}
//"
//If you find the item you are looking for, you need to print "(found!)" next to it:
//"* {itemN} - {count} (found!)"


using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] clothes = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = clothes[0];
                string[] clothesType = clothes[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int j = 0; j < clothesType.Length; j++)
                    {
                        string currCloth = clothesType[j];
                        if (!wardrobe[color].ContainsKey(currCloth))
                        {
                            wardrobe[color].Add(currCloth, 1);
                        }
                        else
                        {
                            wardrobe[color][currCloth]++; ;
                        }
                        
                    }
                }
                else
                {
                    for (int j = 0; j < clothesType.Length; j++)
                    {
                        string currCloth = clothesType[j];
                        if (wardrobe[color].ContainsKey(currCloth))
                        {
                            wardrobe[color][currCloth]++;
                        }
                        else
                        {
                            wardrobe[color].Add(currCloth, 1);
                        }
                    }
                }
            }
            string[] searching = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string clothColor = searching[0].Trim();
            string clotheType = searching[1].Trim();
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color.Key == clothColor && cloth.Key == clotheType)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
