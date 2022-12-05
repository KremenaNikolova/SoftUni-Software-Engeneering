using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int STAMINA = 50;
        private const int INCREASE_STAMINA_WITH = 10;
        private const int MAX_STAMINA = 100;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, STAMINA)
        {
        }

        public override void Exercise()
        {
            Stamina += INCREASE_STAMINA_WITH;
            if (Stamina > MAX_STAMINA)
            {
                Stamina = MAX_STAMINA;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
