using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAdress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] nameBeers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] ints = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> adressPerson = new Tuple<string, string>
            {
                FirstItem = $"{nameAdress[0]} {nameAdress[1]}",
                SecondItem = nameAdress[2],
            };

            Tuple<string, int> beersPeron = new Tuple<string, int>
            {
                FirstItem = nameBeers[0],
                SecondItem = int.Parse(nameBeers[1]),
            };

            Tuple<int, double> numbers = new Tuple<int, double>
            {
                FirstItem = int.Parse(ints[0]),
                SecondItem = double.Parse(ints[1]),
            };

            //Console.WriteLine();

            Console.WriteLine($"{adressPerson.FirstItem} -> {adressPerson.SecondItem}");
            Console.WriteLine(string.Join(" -> ", nameBeers));
            Console.WriteLine($"{numbers.FirstItem} -> {numbers.SecondItem}");
        }
    }
}
