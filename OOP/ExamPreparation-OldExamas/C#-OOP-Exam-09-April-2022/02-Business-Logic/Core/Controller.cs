using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Cars;
using Formula1.Models.Contracts;
using Formula1.Models.Pilots;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Business_Logic.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository= new FormulaOneCarRepository();
        }


        public string CreatePilot(string fullName)
        {
            IPilot searchPilot = pilotRepository.FindByName(fullName);
            if (searchPilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot newPilo = new Pilot(fullName);
            pilotRepository.Add(newPilo);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar searchCar = formulaOneCarRepository.FindByName(model);
            if (searchCar!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;
            switch (type)
            {
                case "Ferrari": car = new Ferrari(model, horsepower, engineDisplacement); break;
                case "Williams": car = new Williams(model, horsepower, engineDisplacement); break;
                default: throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            formulaOneCarRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace searchRace= raceRepository.FindByName(raceName);
            if (searchRace!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            Race newRace = new Race(raceName, numberOfLaps);
            raceRepository.Add(newRace);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot searchPilot = pilotRepository.FindByName(pilotName);
            if (searchPilot==null || searchPilot.Car.Model!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            IFormulaOneCar searchCar = formulaOneCarRepository.FindByName(carModel);
            if (searchCar!=null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            searchPilot.AddCar(searchCar);
            formulaOneCarRepository.Remove(searchCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, searchCar.GetType().Name, carModel);
        }


        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot searchPilot = pilotRepository.FindByName(pilotFullName);
            IRace searchRace = raceRepository.FindByName(raceName);

            if (searchRace==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (searchPilot == null || searchPilot.CanRace == false || searchRace.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            searchRace.AddPilot(searchPilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }


        public string StartRace(string raceName)
        {
            IRace searchRace = raceRepository.FindByName(raceName);

            if (searchRace==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (searchRace.Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (searchRace.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            searchRace.TookPlace = true;
            int laps = searchRace.NumberOfLaps;
            var newRace = searchRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(laps));

            var winner = newRace.FirstOrDefault();
            var secondPlace = newRace.Skip(1).FirstOrDefault();
            var thirdPlace = newRace.Skip(2).FirstOrDefault();

            winner.WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {raceName} race.");
            
            return sb.ToString().TrimEnd();
        }


        public string RaceReport()
        {
            foreach (var race in raceRepository.Models)
            {
                race.RaceInfo();
            }
            return null;
        }

        public string PilotReport()
        {
            foreach (var pilot in pilotRepository.Models)
            {
                pilot.ToString();
            }
            return null;
        }


    }
}
