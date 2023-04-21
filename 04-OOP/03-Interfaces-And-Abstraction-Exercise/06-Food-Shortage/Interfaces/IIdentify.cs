using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Interfaces
{
    public interface IIdentify
    {
        string Name { get; }
        int Age { get; }
        int Food { get; }

        public void BuyFood(string name);

    }
}
