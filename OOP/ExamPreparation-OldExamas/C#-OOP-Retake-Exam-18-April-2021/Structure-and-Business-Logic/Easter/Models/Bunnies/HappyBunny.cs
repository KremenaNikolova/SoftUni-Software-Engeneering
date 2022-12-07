using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        public const int ENERGY = 100;

        public HappyBunny(string name) : base(name, ENERGY)
        {
        }
    }
}
