using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals;
using Wild_Farm.Foods;

namespace Wild_Farm
{
    public class Factory
    {
        public static Food GetFoods(string cmd)
        {
            string[] args = cmd.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string name = args[0];

            switch (name)
            {
                case "Fruit": return new Fruit(int.Parse(args[1]));
                case "Meat": return new Meat(int.Parse(args[1]));
                case "Seeds": return new Seeds(int.Parse(args[1]));
                case "Vegetable": return new Vegetable(int.Parse(args[1]));
                default: return null;
            }
        }

        public static Animal GetAnimals(string cmd)
        {
            string[] args = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = args[0];
            string name = args[1];
            double weight = double.Parse(args[2]);

            switch (type)
            {
                case "Cat": return new Cat(name, weight, args[3], args[4]);
                case "Dog": return new Dog(name, weight, args[3]);
                case "Hen": return new Hen(name, weight, double.Parse(args[3]));
                case "Mouse": return new Mouse(name, weight, args[3]);
                case "Owl": return new Owl(name, weight, double.Parse(args[3]));
                case "Tiger": return new Tiger(name, weight, args[3], args[4]);
                default: return null;

            }
        }
    }
}
