using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _01_Vehicles
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicles(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }


        public virtual void Driving(double distance)
        {
            double fuelAmount = fuelQuantity;
            if ((fuelAmount -= distance * fuelConsumption) > 0)
            {
                fuelQuantity -= distance * fuelConsumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        public virtual void Refueling(double amountOfFuel)
        {
            fuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {fuelQuantity:f2}";
        }


    }
}
