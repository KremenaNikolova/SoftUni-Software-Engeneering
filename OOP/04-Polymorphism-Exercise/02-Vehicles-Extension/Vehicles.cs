using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _02_Vehicles_Extension
{
    public abstract class Vehicles
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        protected Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;

            if (fuelQuantity <= tankCapacity)
            {
                this.fuelQuantity = fuelQuantity;
            }
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
        public virtual void Refueling(double amountOfFuel, string type)
        {
            double refueling = fuelQuantity + amountOfFuel;
            if (amountOfFuel < 0.1)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            else if (refueling >= tankCapacity)
            {
                Console.WriteLine($"Cannot fit { amountOfFuel} fuel in the tank");
                return;
            }
            fuelQuantity = refueling;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {fuelQuantity:f2}";
        }


    }
}
