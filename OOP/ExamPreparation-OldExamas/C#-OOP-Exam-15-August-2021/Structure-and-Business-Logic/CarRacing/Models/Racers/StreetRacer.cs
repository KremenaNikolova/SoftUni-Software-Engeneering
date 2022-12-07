using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DRIVING_EXPERIENCE = 10;
        private const string RACING_BEHAVIOR = "aggressive";

        public StreetRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, DRIVING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
