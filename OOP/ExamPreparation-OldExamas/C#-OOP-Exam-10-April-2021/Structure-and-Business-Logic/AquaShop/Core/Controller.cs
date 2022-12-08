using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            switch (aquariumType)
            {
                case "FreshwaterAquarium": aquarium = new FreshwaterAquarium(aquariumName); break;
                case "SaltwaterAquarium": aquarium = new SaltwaterAquarium(aquariumName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            switch (decorationType)
            {
                case "Ornament": decoration = new Ornament(); break;
                case "Plant": decoration = new Plant(); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            switch (fishType)
            {
                case "FreshwaterFish": fish = new FreshwaterFish(fishName, fishSpecies, price); break;
                case "SaltwaterFish": fish = new SaltwaterFish(fishName, fishSpecies, price); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if ((fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium") || (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium"))
            {
                aquarium.AddFish(fish);
            }


            string output = aquarium.Fish.Any(x => x.Name == fishName)
                ? string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName)
                : OutputMessages.UnsuitableWater;

            return output;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var sumOfFishes = aquarium.Fish.Select(x => x.Price).Sum();
            var sumOfDecoation = aquarium.Decorations.Select(x => x.Price).Sum();

            var totalSum = sumOfDecoation + sumOfFishes;
            return string.Format(OutputMessages.AquariumValue, aquariumName, totalSum);
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, aquariums.Select(x => x.GetInfo()));
        }
    }
}
