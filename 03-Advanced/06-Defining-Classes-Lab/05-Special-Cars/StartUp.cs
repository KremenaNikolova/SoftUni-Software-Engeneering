using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] tires = new Tire[4];

                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    int year = int.Parse(tokens[count]);
                    count++;
                    double pressure = double.Parse(tokens[count]);
                    tires[i] = new Tire(year, pressure);
                    count++;
                }
                tiresList.Add(tires);
                input = Console.ReadLine();
            }

            List<Engine> enginesList = new List<Engine>();
            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);
                enginesList.Add(new Engine(horsePower, cubicCapacity));

                input = Console.ReadLine();
            }

            List<Car> carsesList = new List<Car>();
            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Engine engine = enginesList[engineIndex];
                Tire[] tires = tiresList[tiresIndex];
                carsesList.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires));

                input = Console.ReadLine();
            }

            List<Car> specialCars = carsesList
                .FindAll(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Select(y => y.Pressure).Sum() > 9
                && x.Tires.Select(y => y.Pressure).Sum() < 10);

            foreach (Car car in specialCars)
            {
                car.Drive(car.FuelQuantity, car.FuelConsumption);
                Console.WriteLine(car.ShowSpecial());
            }

        }


    }
}
