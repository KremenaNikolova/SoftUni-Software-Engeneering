using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_Pokemon_Trainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBagde { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void CheckPokemonElement(string element)
        {
            if (this.Pokemons.Any(p => p.Element == element))
            {
                this.NumberOfBagde++;
            }
            else
            {
                for (int i = 0; i < this.Pokemons.Count; i++)
                {
                    Pokemon currPoke = this.Pokemons[i];
                    currPoke.Health -= 10;

                    if (currPoke.Health <= 0)
                    {
                        this.Pokemons.Remove(currPoke);
                    }
                }
            }
        }
    }
}
