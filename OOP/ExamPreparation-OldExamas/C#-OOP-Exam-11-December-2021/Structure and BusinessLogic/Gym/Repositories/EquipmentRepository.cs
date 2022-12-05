using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipmentsList;

        public EquipmentRepository()
        {
            equipmentsList = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => equipmentsList.AsReadOnly();


        public void Add(IEquipment model)
        {
            equipmentsList.Add(model);
        }
        public bool Remove(IEquipment model)
        {
            return equipmentsList.Remove(model);
        }
        public IEquipment FindByType(string type)
        {
            return equipmentsList.FirstOrDefault(x=>x.GetType().Name == type);
        }

    }
}
