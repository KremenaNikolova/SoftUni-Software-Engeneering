using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) 
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;

        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }


        public void Drive(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity -= (fuelConsumption/100)*20;
        }
       
        public string ShowSpecial()
        {
            StringBuilder carsInformation = new StringBuilder();

            carsInformation.AppendLine($"Make: {this.Make}");
            carsInformation.AppendLine($"Model: {this.Model}");
            carsInformation.AppendLine($"Year: {this.Year}");
            carsInformation.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            carsInformation.AppendLine($"FuelQuantity: {this.FuelQuantity}");
            return carsInformation.ToString().TrimEnd();
        }
    }

}
