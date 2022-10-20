using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;

        public Net(string material, int capacity)
        {
            fish = new List<Fish>();

            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish { get { return this.fish; } }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => fish.Count;
        

        public string AddFish(Fish fish) //adds a Fish to the fish's collection if there is room for it. Before adding a fish, check:
        {
            //If the fish type is null or whitespace.
            //If the fish’s length or weight is zero or less.
            //If the fish type, length, or weight properties are not valid, return: "Invalid fish."
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length<=0 || fish.Weight<=0)
            {
                return "Invalid fish.";
            }
            //If the net is full (there is no room for more fish), return "Fishing net is full.". 
            else if (Capacity==Count)
            {
                return "Fishing net is full.";
            }
            //Otherwise, return: "Successfully added {fishType} to the fishing net."
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight) // removes a fish by given weight, if such exists return true, otherwise false.
        {
            return fish.Remove(fish.First(x => x.Weight == weight));
        }

        public Fish GetFish(string fishType) // search and returns a fish by given fish type.
        {
            return fish.FirstOrDefault(x=>x.FishType==fishType);
        }
        public Fish GetBiggestFish()// search and returns the longest fish in the collection.{
        {
            return fish.OrderByDescending(x=>x.Weight).First();
        }
        public string Report() // returns information about the Net and all fish that were not released, order by fish's length descending  in the following format:	
        {
            var orderedFishes = fish.OrderByDescending(x => x.Length);
            return $"Into the {Material}:{Environment.NewLine}{string.Join(Environment.NewLine, orderedFishes)}.";
            
        }
    }
}
