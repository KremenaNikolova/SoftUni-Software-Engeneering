using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronautsList;
        public AstronautRepository()
        {
            astronautsList= new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => astronautsList.AsReadOnly();

        public void Add(IAstronaut model)
        {
            astronautsList.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return astronautsList.FirstOrDefault(x=>x.Name==name);
        }

        public bool Remove(IAstronaut model)
        {
            return astronautsList.Remove(model);
        }
    }
}
