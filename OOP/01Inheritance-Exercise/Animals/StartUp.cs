using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            string typeOfAnimal = string.Empty;
            while ((typeOfAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = string.Empty;
                if (tokens.Length>2) gender = tokens[2];

                Animal animal = new Animal(name, age, gender);
                if (typeOfAnimal == "Dog")
                {
                    animal = new Dog(name, age, gender);
                }
                else if (typeOfAnimal == "Cat")
                {
                    animal = new Cat(name, age, gender);
                }
                else if (typeOfAnimal == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }
                else if (typeOfAnimal == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else if (typeOfAnimal == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
                list.Add(animal);
            }

            foreach (var animal in list)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
