﻿using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacyModels;

        public DelicacyRepository()
        {
            delicacyModels= new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => delicacyModels.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            delicacyModels.Add(model);
        }
    }
}
