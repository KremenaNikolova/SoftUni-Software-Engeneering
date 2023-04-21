using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();

            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal) //  adds an Animal to the animals' collection if there is room for it. Before adding an animal, check:
        {
            //If the animal species is null or whitespace, return "Invalid animal species."
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }
            //If the animal’s diet is different from "herbivore" or "carnivore", return "Invalid animal diet."
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            //If the zoo is full (there is no room for more animals), return "The zoo is full."
            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }
            //Otherwise, return: "Successfully added {animal species} to the zoo."
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }


        public int RemoveAnimals(string species) // removes all animals by given species, as a result, return the count of the animals which were removed.
        {
            return Animals.RemoveAll(x => x.Species == species);
        }
        public List<Animal> GetAnimalsByDiet(string diet) //search and returns a list of animals by given diet.
        {
            return Animals.FindAll(x => x.Diet == diet);
        }
        public Animal GetAnimalByWeight(double weight) //return the first animal, with the given weight.
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength) //search of all animals which has a length between the given (inclusively). As a result return the following format: "There are {count} animals with a length between {minimum length} and {maximum length} meters."
        {
            var findAnimals = Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength);
            int count = findAnimals.Count;

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
