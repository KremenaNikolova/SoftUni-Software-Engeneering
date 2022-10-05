using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumptionPerkilometer { get { return fuelConsumptionPerKilometer; } set { fuelConsumptionPerKilometer = value; } }
        public double TravelledDistance { get { return travelledDistance; } set { travelledDistance = value; } }

        public void CarMoving(double amountOfKm)
        {
            if (this.fuelConsumptionPerKilometer* amountOfKm <= fuelAmount)
            {
                this.fuelAmount -= this.fuelConsumptionPerKilometer * amountOfKm;
                this.travelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }

    }
}
