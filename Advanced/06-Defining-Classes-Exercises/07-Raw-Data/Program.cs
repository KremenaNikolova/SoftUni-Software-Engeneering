//Create a program that tracks cars and their cargo.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int carsNumber = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsNumber; i++)
            {
                string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInformation[0];
                int engineSpeed = int.Parse(carInformation[1]);
                int enginePower = int.Parse(carInformation[2]);
                int cargoWeight = int.Parse(carInformation[3]);
                string cargoType = carInformation[4];
                float tire1Pressure = float.Parse(carInformation[5]);
                int tire1Age = int.Parse(carInformation[6]);
                float tire2Pressure = float.Parse(carInformation[7]);
                int tire2Age = int.Parse(carInformation[8]);
                float tire3Pressure = float.Parse(carInformation[9]);
                int tire3Age = int.Parse(carInformation[10]);
                float tire4Pressure = float.Parse(carInformation[11]);
                int tire4Age = int.Parse(carInformation[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age),
                };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> fragile = cars
                .FindAll(x => x.Cargo.Type == "fragile"
                && x.Tires.Any(y => y.Pressure < 1));
            List<Car> flammable = cars
                .FindAll(x => x.Cargo.Type == "flammable"
                && x.Engine.Power > 250);

            if (command=="fragile")
            {
                foreach (var car in fragile)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command=="flammable")
            {
                foreach (var car in flammable)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}
