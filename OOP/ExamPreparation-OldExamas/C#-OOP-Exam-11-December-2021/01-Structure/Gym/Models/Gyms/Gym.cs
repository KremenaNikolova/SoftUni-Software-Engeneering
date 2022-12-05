using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment; //first test in judge
        private List<IAthlete> athletes; //first test in judge

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity {get; private set; }  //number of Athletes which can exercise in the Gym

        public double EquipmentWeight => CalculateEquipmentWeight();  //The sum of each equipment’s weight in the Gym

        private double CalculateEquipmentWeight()
        {
            double result = 0;
            foreach (var item in Equipment)
            {
                result += item.Weight;
            }
            return result;
        }

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes =>athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity==Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var item in Athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string outputAtlethes = Athletes.Count == 0 ? "No athletes" : string.Join(", ", Athletes);

            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {outputAtlethes}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");

            return sb.ToString().TrimEnd();
        }

    }
}
