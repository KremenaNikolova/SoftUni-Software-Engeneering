using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder print = new StringBuilder();
            string typeOfAnimal = string.Empty;
            while ((typeOfAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = string.Empty;
                if (tokens.Length>2) gender = tokens[2];
                if (age<0 || string.IsNullOrEmpty(name) || (gender!="Female" && gender!="Male"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (typeOfAnimal == "Kitten")
                {
                    gender = "Female";
                }
                else if (typeOfAnimal == "Tomcat")
                {
                    gender = "Male";
                }
                print.AppendLine($"{typeOfAnimal}");
                print.AppendLine($"{name} {age} {gender}");

                if (typeOfAnimal == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    print.AppendLine($"{dog.ProduceSound()}");
                }
                else if (typeOfAnimal == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    print.AppendLine($"{cat.ProduceSound()}");
                }
                else if (typeOfAnimal == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    print.AppendLine($"{frog.ProduceSound()}");
                }
                else if (typeOfAnimal == "Kitten")
                {
                    Kitten kittens = new Kitten(name, age, gender);
                    print.AppendLine($"{kittens.ProduceSound()}");
                }
                else if (typeOfAnimal == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age,gender);
                    print.AppendLine($"{tomcat.ProduceSound()}");
                }
                
            }
            Console.WriteLine(print);
            
        }
    }
}
