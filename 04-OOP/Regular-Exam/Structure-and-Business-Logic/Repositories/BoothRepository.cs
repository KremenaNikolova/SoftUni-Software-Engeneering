using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> boothsModels;

        public BoothRepository()
        {
            boothsModels= new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => boothsModels.AsReadOnly();

        public void AddModel(IBooth model)
        {
            boothsModels.Add(model);
        }
    }
}
