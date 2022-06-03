using System;

namespace _07_Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            //valid code 0.1 0.2 0.5 1 2
            //if invalid "Cannot accept {money}" 

            string money = Console.ReadLine();
            double price = 0;
            double sumMoney = 0;

            while (money != "Start")
            {

                if (money != "0.1" && money != "0.2" && money != "0.5" && money != "1" && money != "2")
                {
                    Console.WriteLine($"Cannot accept {money}");
                    money = Console.ReadLine();
                    continue;
                }
                double allMoney = double.Parse(money);

                sumMoney += allMoney;
                money = Console.ReadLine();

            }
            if (money == "Start")
            {
                string product = Console.ReadLine();
                while (product != "End")
                {
                    if (product == "Nuts")
                    {
                        price = 2;
                    }
                    else if (product == "Water")
                    {
                        price = 0.7;
                    }
                    else if (product == "Crisps")
                    {
                        price = 1.5;
                    }
                    else if (product == "Soda")
                    {
                        price = 0.8;
                    }
                    else if (product == "Coke")
                    {
                        price = 1;
                    }
                    sumMoney -= price;
                    if (product != "Nuts" && product != "Water" && product != "Crisps" && product != "Soda" && product != "Coke")
                    {
                        Console.WriteLine("Invalid product");

                    }
                    else if (sumMoney < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sumMoney += price;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                    }
                    product = Console.ReadLine();

                }
                Console.WriteLine($"Change: {sumMoney:f2}");
            }
        }



    }
}
