using System;
using System.Collections.Generic;

namespace _08_Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineLines; i++)
            {
                string[] engineInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInformation[0];
                int power = int.Parse(engineInformation[1]);

                Engine engine = new Engine(engineModel, power);

                if (engineInformation.Length > 2)
                {
                    int displacement;
                    bool isDigit = int.TryParse(engineInformation[2], out displacement);
                    if (!isDigit)
                    {
                        string efficiency = engineInformation[2];
                        engine = new Engine(engineModel, power, efficiency);
                    }
                    else
                    {
                        engine = new Engine(engineModel, power, displacement);
                    }
                    if (engineInformation.Length > 3)
                    {
                        string efficiency = engineInformation[3];
                        engine = new Engine(engineModel, power, displacement, efficiency);
                    }
                }
                engines.Add(engine);

            }

            int carLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < carLines; i++)
            {
                string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInformation[0];
                string engineModel = carInformation[1];
                Engine engine = engines.Find(e => e.Model == engineModel);
                Car car = new Car(carModel, engine);

                if (carInformation.Length > 2)
                {
                    int weight;
                    bool isDigit = int.TryParse(carInformation[2], out weight);
                    if (!isDigit)
                    {
                        string color = carInformation[2];
                        car = new Car(carModel, engine, color);
                    }
                    else
                    {
                        car = new Car(carModel, engine, weight);
                    }
                    
                    if (carInformation.Length > 3)
                    {
                        string color = carInformation[3];
                        car = new Car(carModel, engine, weight, color);
                    }
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
