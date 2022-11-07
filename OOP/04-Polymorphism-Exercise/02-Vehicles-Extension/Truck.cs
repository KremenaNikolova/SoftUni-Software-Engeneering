using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles
{
    public class Truck : Vehicles

    {
        private const double CONSUMPTION_INCREASE = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE) {}

        public override void Driving(double distance)
        {
            base.Driving(distance);
        }
        public override void Refueling(double amountOfFuel)
        {
            amountOfFuel -= amountOfFuel * 0.05;
            base.Refueling(amountOfFuel);
            
        }
    }
}
