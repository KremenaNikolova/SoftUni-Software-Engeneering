using System;

namespace _04_Pizza_Calories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split();
                string[] doughInput = Console.ReadLine().Split();
                Dough dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split();
                    string toppingType = tokens[1];
                    double toppingGrams = double.Parse(tokens[2]);

                    Topping topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }

            catch (Exception message)
            {

                Console.WriteLine(message.Message);
            }


        }
    }
}
