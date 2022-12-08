using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            decorations= new List<IDecoration>();
            fishes= new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity {get; private set; } //The number of Fish аn Aquarium can have

        public int Comfort => CalculatedComfort();

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        private int CalculatedComfort()
        {
            return decorations.Sum(x => x.Comfort);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Count==Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishInfo = fishes.Any() ? string.Join(", ", fishes.Select(x => x.Name)) : "none";

            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.AppendLine($"Fish: {fishInfo}");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

    }
}
