using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racersList;

        public RacerRepository()
        {
            racersList= new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racersList.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            racersList.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return racersList.FirstOrDefault(x=>x.Username==property);
        }

        public bool Remove(IRacer model)
        {
            return racersList.Remove(model);
        }
    }
}
