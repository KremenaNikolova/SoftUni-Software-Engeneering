using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planetsList;
        public PlanetRepository()
        {
            planetsList = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planetsList.AsReadOnly();

        public void Add(IPlanet model)
        {
            planetsList.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planetsList.FirstOrDefault(x=> x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return planetsList.Remove(model);
        }
    }
}
