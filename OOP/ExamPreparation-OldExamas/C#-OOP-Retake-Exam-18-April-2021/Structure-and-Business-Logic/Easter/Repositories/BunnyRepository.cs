using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunniesList;

        public BunnyRepository()
        {
            bunniesList= new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunniesList.AsReadOnly();

        public void Add(IBunny model)
        {
            bunniesList.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return bunniesList.FirstOrDefault(x=> x.Name == name); 
        }

        public bool Remove(IBunny model)
        {
            return bunniesList.Remove(model);
        }
    }
}
