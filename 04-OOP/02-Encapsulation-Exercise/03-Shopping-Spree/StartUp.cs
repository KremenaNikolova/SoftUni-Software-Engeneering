using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace _03_Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            //Peter = 11; George = 4;
            //Bread = 10; Milk = 2;
            string[] peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Count(); i++)
            {
                try
                {
                    string[] tokens = peopleInput[i].Split("=");
                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception message)
                {

                    Console.WriteLine(message.Message);
                    return;
                }
                
            }
            for (int i = 0; i < productInput.Count(); i++)
            {
                try
                {
                    string[] tokens = productInput[i].Split("=");
                    string name = tokens[0];
                    decimal cost = decimal.Parse(tokens[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (Exception message)
                {

                    Console.WriteLine(message.Message);
                    return;
                }
                
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                //Peter Bread
                //George Milk
                //George Milk
                //Peter Milk

                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string personName= tokens[0];
                string productName = tokens[1];
                
                var persons = people.Find(p => p.Name == personName);
                persons.AddPerson(products.Find(p=>p.Name==productName));
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));




        }
    }
}
