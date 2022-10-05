using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            //each car model must be unique
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
           
            for (int i = 0; i < numberOfCars; i++)
            {
                //input for each car
                string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInformation[0];
                double fuelAmount = double.Parse(carInformation[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInformation[2]);

                Car car = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerkilometer = fuelConsumptionPerKilometer,
                };

                if (!cars.ContainsKey(model))
                {
                    cars.Add(car.Model, car);
                    //list is with {mode} {fuelAmount} {fuelConsumptionPerKm}
                }
                 //all cars start at 0 km traveled

            }
            string command = Console.ReadLine();
            while (command!="End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car car = cars[model];
                car.CarMoving(amountOfKm);

                command = Console.ReadLine();
            }

            //output must be "{model} {fuelAmount} {distanceTraveled}

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
