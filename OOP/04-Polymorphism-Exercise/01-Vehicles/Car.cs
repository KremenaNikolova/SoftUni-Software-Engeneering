using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles
{
    public class Car : Vehicles
    {
        private const double CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE) { }

        public override void Driving(double distance)
        {
            base.Driving(distance);
        }
        public override void Refueling(double amountOfFuel)
        {
            base.Refueling(amountOfFuel);
        }
    }
}
