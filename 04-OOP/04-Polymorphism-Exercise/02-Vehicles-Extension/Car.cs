using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension
{
    public class Car : Vehicles
    {
        private const double CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE, tankCapacity) { }

    }
}
