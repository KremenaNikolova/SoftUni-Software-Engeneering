using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _02_Vehicles_Extension
{
    public class Bus : Vehicles
    {
        private const double CONSUMPTION_INCREASE = 1.4;
        private double fuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption+CONSUMPTION_INCREASE, tankCapacity) {}

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public override double FuelQuantity { get => base.FuelQuantity; set => base.FuelQuantity = value; }

        public void DriveEmty(double distance)
        {
            this.FuelConsumption = fuelConsumption;
            Driving(distance);
        }


    }
}
