using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _02_Vehicles_Extension
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }
        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                double startCapacity = fuelQuantity;
                if (startCapacity>tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity=value;
                }
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
        public virtual void Refueling(double amountOfFuel)
        {
            double refueling = fuelQuantity + amountOfFuel;
            if (amountOfFuel < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            else if (refueling > tankCapacity)
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
