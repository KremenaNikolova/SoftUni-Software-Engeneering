using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> carList;

        public CarRepository()
        {
            carList= new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => carList.AsReadOnly();

        public void Add(ICar model)
        {
            if (model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            carList.Add(model);
        }

        public ICar FindBy(string property)
        {
            return carList.FirstOrDefault(x=>x.VIN== property);
        }

        public bool Remove(ICar model)
        {
            return carList.Remove(model);
        }
    }
}
