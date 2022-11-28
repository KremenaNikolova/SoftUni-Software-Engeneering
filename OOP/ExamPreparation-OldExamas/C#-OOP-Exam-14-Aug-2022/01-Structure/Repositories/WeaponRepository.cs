using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models= new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models;

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string weaponName)
        {
            return Models.FirstOrDefault(x=>x.GetType().Name== weaponName);
        }

        public bool RemoveItem(string name)
        {
            return models.Remove(models.Find(x=>x.GetType().Name== name));
        }
    }
}
