using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorationsList;

        public DecorationRepository()
        {
            decorationsList= new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => decorationsList.AsReadOnly();

        public void Add(IDecoration model)
        {
            decorationsList.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return decorationsList.FirstOrDefault(x=>x.GetType().Name== type);
        }

        public bool Remove(IDecoration model)
        {
            return decorationsList.Remove(model);
        }
    }
}
