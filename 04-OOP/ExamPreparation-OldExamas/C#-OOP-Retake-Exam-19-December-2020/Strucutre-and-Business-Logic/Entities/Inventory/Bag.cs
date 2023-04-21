using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> itemsList;

        public Bag(int capacity)
        {
            Capacity= capacity;

            itemsList= new List<Item>();
        }

        public int Capacity {get; set;}

        public int Load => CalculateLoad();

        public IReadOnlyCollection<Item> Items => itemsList.AsReadOnly();

        private int CalculateLoad()
        {
            return itemsList.Sum(x => x.Weight);
        }

        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            itemsList.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!itemsList.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = itemsList.FirstOrDefault(x=>x.GetType().Name == name);
            if (item==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            
            itemsList.Remove(item); 
            return item;
        }
    }
}
