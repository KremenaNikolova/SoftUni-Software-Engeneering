using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension
{
    public class Truck : Vehicles

    {
        private const double CONSUMPTION_INCREASE = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE, tankCapacity) {}

        public override double FuelQuantity { get => base.FuelQuantity; set => base.FuelQuantity = value; }
        public override void Driving(double distance)
        {
            base.Driving(distance);
        }
        public override void Refueling(double amountOfFuel)
        {
            base.Refueling(amountOfFuel * 0.95);
        }
    }
}
