using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggsList;
        public EggRepository()
        {
            eggsList= new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggsList.AsReadOnly();

        public void Add(IEgg model)
        {
            eggsList.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return eggsList.FirstOrDefault(x=>x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return eggsList.Remove(model);
        }
    }
}
