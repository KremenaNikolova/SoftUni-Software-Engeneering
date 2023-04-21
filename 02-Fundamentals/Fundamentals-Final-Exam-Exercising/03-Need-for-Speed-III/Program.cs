using System;
using System.Collections.Generic;

namespace _03_Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();
            
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInformation = Console.ReadLine().Split("|");
                cars.Add(carInformation[0], new List<int> { int.Parse(carInformation[1]), int.Parse(carInformation[2]) });

            }

            string[] command = Console.ReadLine().Split(" : ");
            while (command[0]!="Stop")
            {
                string action = command[0];
                switch (action)
                {
                    case "Drive":
                        Drive(command[1], int.Parse(command[2]), int.Parse(command[3]), cars);
                        break;
                    case "Refuel":
                        Refuel(command[1], int.Parse(command[2]), cars);
                        break;
                    case "Revert":
                        Revert(command[1], int.Parse(command[2]), cars);
                        break;
                }

                command = Console.ReadLine().Split(" : ");
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }

        static void Drive(string car, int distance, int fuel, Dictionary<string, List<int>> cars)
        {
            if (cars[car][1]<fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }
            cars[car][1] -= fuel;
            cars[car][0] += distance;

            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (cars[car][0]>=100000)
            {
                cars.Remove(car);
                Console.WriteLine($"Time to sell the {car}!");
                return;
            }

            
        }

        static void Refuel(string car, int fuel, Dictionary<string, List<int>> cars)
        {
            int copyOfOriginalFuel = cars[car][1]; 
            cars[car][1] += fuel;                 
            if (cars[car][1]>75)
            {
                cars[car][1] = 75;
                fuel = 75 - copyOfOriginalFuel;
            }
            Console.WriteLine($"{car} refueled with {fuel} liters");
        }

        static void Revert(string car, int kilometers, Dictionary<string, List<int>> cars)
        {
            cars[car][0] -= kilometers;
            if (cars[car][0]<10000)
            {
                cars[car][0] = 10000;
                return;
            }
            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
        }
    }
}
