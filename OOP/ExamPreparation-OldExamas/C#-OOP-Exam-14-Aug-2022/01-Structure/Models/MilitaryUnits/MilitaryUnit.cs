﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            enduranceLevel = 1;
            Cost= cost;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set
            {
                if (enduranceLevel>20)
                {
                    enduranceLevel = 20;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                enduranceLevel= value;
            }
        }

        public void IncreaseEndurance()
        {
            enduranceLevel++;
        }
    }
}
