using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weaponModels;
        public WeaponRepository()
        {
            weaponModels = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weaponModels.AsReadOnly();

        public void Add(IWeapon model)
        {
            weaponModels.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weaponModels.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return weaponModels.Remove(model);
        }
    }
}
