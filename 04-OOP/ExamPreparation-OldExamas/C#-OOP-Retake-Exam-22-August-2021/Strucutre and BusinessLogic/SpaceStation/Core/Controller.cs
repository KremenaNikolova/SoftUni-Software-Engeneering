using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        private IRepository<IAstronaut> astronauts;
        private int exploredPlanetCount = 0;

        public Controller()
        {
            planets = new PlanetRepository();
            astronauts= new AstronautRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astrounat;
            switch (type)
            {
                case "Biologist": astrounat = new Biologist(astronautName); break;
                case "Geodesist": astrounat = new Geodesist(astronautName); break;
                case "Meteorologist": astrounat = new Meteorologist(astronautName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronauts.Add(astrounat);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);
            if (astronaut==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IMission mission = new Mission();
            var planet = planets.FindByName(planetName);
            var availibleAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToArray();
            if (availibleAstronauts.Length==0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, availibleAstronauts);
            exploredPlanetCount++;
            return string.Format(OutputMessages.PlanetExplored, planetName, availibleAstronauts.Count(x=>x.Oxygen<=0));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                string bagInformation = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";

                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {bagInformation}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
