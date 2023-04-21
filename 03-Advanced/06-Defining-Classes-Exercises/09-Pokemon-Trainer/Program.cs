using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (input!= "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0]; //trainer name is unique - Trainer
                string pokemonName = tokens[1]; // Pokemon name
                string pokemonElement = tokens[2]; //Pokemon element
                int pokemonHealth = int.Parse(tokens[3]); // pokemon Health

                Trainer trainer = trainers.SingleOrDefault(x => x.Name == trainerName);
                if (trainer==null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine(); //fire, water, electricyti, end
            while (command!="End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.CheckPokemonElement(command);
                }
                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t=>t.NumberOfBagde))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBagde} {trainer.Pokemons.Count}");
            }
        }


        //output = trainer, badges, number of pokemons = class Trainer
    }
}
