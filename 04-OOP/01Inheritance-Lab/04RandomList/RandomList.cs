using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    internal class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(this.Count);
            string removed = this[index];
            RemoveAt(index);
            return removed;

        }
    }
}
