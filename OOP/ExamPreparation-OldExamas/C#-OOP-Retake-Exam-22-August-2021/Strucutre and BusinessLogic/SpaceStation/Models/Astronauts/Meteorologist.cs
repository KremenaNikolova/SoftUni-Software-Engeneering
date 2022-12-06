using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        public const double OXYGEN = 90;

        public Meteorologist(string name) : base(name, OXYGEN)
        {
        }
    }
}
