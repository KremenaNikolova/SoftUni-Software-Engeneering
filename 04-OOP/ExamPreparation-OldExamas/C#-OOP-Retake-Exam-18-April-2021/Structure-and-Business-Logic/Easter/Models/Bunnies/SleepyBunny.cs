using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        public const int ENERGY = 50;

        public SleepyBunny(string name) : base(name, ENERGY)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= 5;
        }
    }
}
