using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            while (true)
            {
                string input = Console.ReadLine();
                string[] tokensFromInput = input.Split("/");

                if (input=="end")
                {
                    break;
                }

                string carOrTruck = tokensFromInput[0];
                string brand = tokensFromInput[1];
                string model = tokensFromInput[2];
                double powerOrWeight = double.Parse(tokensFromInput[3]);

                if (carOrTruck=="Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = powerOrWeight
                    };
                    catalogue.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = powerOrWeight
                    };
                    catalogue.Trucks.Add(truck);
                }

            }

            List<Car> sortedCars = catalogue.Cars.OrderBy(alphaBet=>alphaBet.Brand).ToList();

            Console.WriteLine("Cars:");
            foreach (Car car in sortedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            List<Truck> sortedTrucks = catalogue.Trucks.OrderBy(alhaBet => alhaBet.Brand).ToList();

            Console.WriteLine("Trucks:");
            foreach (Truck truck in sortedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
            
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    public class Catalogue
    {

        public Catalogue()
        {
            this.Trucks = new List<Truck>();
            this.Cars = new List<Car>();
        }

        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
