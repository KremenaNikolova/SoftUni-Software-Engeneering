using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bag;
using SpaceStation.Models.Bag.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const double OXYGEN_DECREASE = 10;

        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;

            bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), ExceptionMessages.InvalidAstronautName); //may judge throw X

                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath {get; private set;}

        public IBag Bag => bag;

        public virtual void Breath()
        {
            Oxygen -= OXYGEN_DECREASE;
        }
    }
}
