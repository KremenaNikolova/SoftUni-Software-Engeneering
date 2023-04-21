using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public const double OXYGEN = 70;
        public const double DECREASE_OXYGEN = 5;

        public Biologist(string name) : base(name, OXYGEN)
        {
        }

        public override void Breath()
        {
            Oxygen -= DECREASE_OXYGEN;
        }
    }
}
