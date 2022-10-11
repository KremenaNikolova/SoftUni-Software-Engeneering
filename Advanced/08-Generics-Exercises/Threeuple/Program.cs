using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personAdressInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] personBeersInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] personBankAccountInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> personAdress = new Threeuple<string, string, string>
            {
                FirstItem = $"{personAdressInformation[0]} {personAdressInformation[1]}",
                SecondItem = personAdressInformation[2],
                ThirdItem = personAdressInformation[3]
            };

            Threeuple<string, int, bool> personBeers = new Threeuple<string, int, bool>
            {
                FirstItem = personBeersInformation[0],
                SecondItem = int.Parse(personBeersInformation[1]),
                ThirdItem = personBeersInformation[2] == "drunk"
            };

            Threeuple<string, double, string> personBankAccount = new Threeuple<string, double, string>
            {
                FirstItem = personBankAccountInformation[0],
                SecondItem = double.Parse(personBankAccountInformation[1]),
                ThirdItem = personBankAccountInformation[2]
            };

            Console.WriteLine($"{personAdress.FirstItem} -> {personAdress.SecondItem} -> {personAdress.ThirdItem}");
            Console.WriteLine($"{personBeers.FirstItem} -> {personBeers.SecondItem} -> {personBeers.ThirdItem}");
            Console.WriteLine($"{personBankAccount.FirstItem} -> {personBankAccount.SecondItem} -> {personBankAccount.ThirdItem}");
        }
    }
}
