using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipmentRepository;
        private List<IGym> gymsList;

        public Controller()
        {
            equipmentRepository = new EquipmentRepository();
            gymsList = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            switch (gymType)
            {
                case "BoxingGym": gym = new BoxingGym(gymName); break;
                case "WeightliftingGym": gym = new WeightliftingGym(gymName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gymsList.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            switch (equipmentType)
            {
                case "BoxingGloves": equipment = new BoxingGloves(); break;
                case "Kettlebell": equipment = new Kettlebell(); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipmentRepository.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = equipmentRepository.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = gymsList.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            switch (athleteType)
            {
                case "Boxer": athlete = new Boxer(athleteName, motivation, numberOfMedals); break;
                case "Weightlifter": athlete = new Weightlifter(athleteName, motivation, numberOfMedals); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = gymsList.FirstOrDefault(x => x.Name == gymName);
            if (athlete is Boxer && gym is BoxingGym)
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else if (athlete is Weightlifter && gym is WeightliftingGym)
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gymsList.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gymsList.FirstOrDefault(x => x.Name == gymName);
            double equipemtnsWeightSum = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, equipemtnsWeightSum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gymsList)
            {
                //sb.AppendLine($"{gym.Name} is a {gym.GetType().Name}:");
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }




    }

}
