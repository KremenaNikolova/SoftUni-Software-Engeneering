using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> coctailsModels;

        public CocktailRepository()
        {
            coctailsModels= new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => coctailsModels.AsReadOnly();

        public void AddModel(ICocktail model)
        {
            coctailsModels.Add(model);
        }
    }
}
