using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (!racerOne.IsAvailable() || !racerTwo.IsAvailable())
            {
                string winnerUsername = racerOne.IsAvailable() ? $"{racerOne.Username}" : $"{racerTwo.Username}";
                string lostUsername = !racerOne.IsAvailable() ? $"{racerOne.Username}" : $"{racerTwo.Username}";

                return string.Format(OutputMessages.OneRacerIsNotAvailable, winnerUsername, lostUsername);
            }
            double racerOneRacingBehavior = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double racerTwoRacingBehavior = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneRacingBehavior;
            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoRacingBehavior;

            string winner = chanceOfWinningRacerOne > chanceOfWinningRacerTwo ? racerOne.Username : racerTwo.Username;

            racerOne.Race();
            racerTwo.Race();
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);

        }
    }
}
