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
        public override void Refueling(double amountOfFuel, string type)
        {
            double truckRefueling = amountOfFuel * 0.95;
            if (amountOfFuel < 0.1)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            else if (truckRefueling>this.tankCapacity)
            {
                Console.WriteLine($"Cannot fit {amountOfFuel} fuel in the tank");
                return;
            }
            fuelQuantity+=truckRefueling;
        }
    }
}
