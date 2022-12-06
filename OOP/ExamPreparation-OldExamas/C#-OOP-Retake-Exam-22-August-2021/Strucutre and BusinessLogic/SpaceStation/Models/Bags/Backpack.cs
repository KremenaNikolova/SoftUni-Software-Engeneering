using SpaceStation.Models.Bag.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bag
{
    public class Backpack : IBag
    {
        private List<string> bags;

        public Backpack()
        {
            bags = new List<string>();
        }
        public ICollection<string> Items => bags;
    }
}
