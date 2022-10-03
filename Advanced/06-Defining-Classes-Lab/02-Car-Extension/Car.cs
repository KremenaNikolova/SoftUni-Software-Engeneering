using System;
using System.Text;

namespace CarManufacturer
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string  Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double spendFuel = distance * this.fuelConsumption;
            if (fuelQuantity - spendFuel >= 0)
            {
                this.fuelQuantity -= spendFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }

        }
        public string WhoAmI()
        {
            StringBuilder whoAmI = new StringBuilder();
            whoAmI.AppendLine($"Make: {this.Make}");
            whoAmI.AppendLine($"Model: {this.Model}");
            whoAmI.AppendLine($"Year: {this.Year}");
            whoAmI.AppendLine($"Fuel: {this.FuelQuantity:f2}");
            return whoAmI.ToString();
        }
    }

}
