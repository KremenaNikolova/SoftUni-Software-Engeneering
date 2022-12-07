using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double AVAILABLE_FUEL = 65;
        private const double FUEL_CONSUMPTION_PER_RACE = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, AVAILABLE_FUEL, FUEL_CONSUMPTION_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            double decreaseHorsePower = HorsePower - (HorsePower * 0.03);
            HorsePower =(int)decreaseHorsePower;
        }
    }
}
