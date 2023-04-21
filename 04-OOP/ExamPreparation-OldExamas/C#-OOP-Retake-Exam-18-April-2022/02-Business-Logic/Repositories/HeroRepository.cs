using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroModels;

        public HeroRepository()
        {
            heroModels= new List<IHero>();
        }


        public IReadOnlyCollection<IHero> Models => heroModels.AsReadOnly();



        public void Add(IHero model)
        {
            heroModels.Add(model);
        }

        public IHero FindByName(string name)
        {
            return Models.FirstOrDefault(x=>x.Name==name);
        }

        public bool Remove(IHero model)
        {
            return heroModels.Remove(model);
        }
    }
}
