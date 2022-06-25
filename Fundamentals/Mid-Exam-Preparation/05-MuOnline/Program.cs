using System;

namespace _05_MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine().Split("|");

            int health = 100;
            int bitcoins = 0;
            int healingUp = 0;
            int counter = 0;
           

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string command=dungeonRooms[i];
                string[] tokens = command.Split();
                string action=tokens[0];
                counter++;
                int number = int.Parse(tokens[1]);
                switch (action)
                {
                    case "potion":
                        if (health<100 && 100>=health+number)
                        {
                            health += number;
                            if (health>100)
                            {   
                                health = 100;
                            }
                            Console.WriteLine($"You healed for {number} hp.");
                        }
                        else if (health==100)
                        {
                            continue;
                        }
                        else
                        {
                            healingUp = 100 - health;
                            health = 100;
                            
                            Console.WriteLine(($"You healed for {healingUp} hp."));
                        }
                        
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins = bitcoins + number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        health -= number;
                        if (health>0)
                        {
                            Console.WriteLine($"You slayed {action}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {action}.");
                            
                        }
                        break;
                }
                if (health<=0)
                {
                    Console.WriteLine($"Best room: {counter}");
                    return; 
                }
                
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");


        }

    }
}
