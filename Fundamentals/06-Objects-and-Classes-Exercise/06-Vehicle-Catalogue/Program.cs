using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicle = new List<Vehicle>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];

                if (type == "End")
                {
                    break;
                }
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);


                var car = new Vehicle();
                car.Type = type;
                car.Model = model;
                car.Color = color;
                car.HorsePower = horsePower;
                vehicle.Add(car);


            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Close the Catalogue")
                {
                    break;
                }
                else
                {
                    foreach (var typeCar in vehicle)
                    {
                        
                        if (typeCar.Model==input)
                        {
                            Console.WriteLine($"Type: {typeCar.Type.First().ToString().ToUpper() + String.Join("", typeCar.Type.Skip(1))}");
                            Console.WriteLine($"Model: {typeCar.Model}");
                            Console.WriteLine($"Color: {typeCar.Color}");
                            Console.WriteLine($"Horsepower: {typeCar.HorsePower}");
                        }
                    }
                }
            }

            double avarageHorsePowerCars = 0;
            double avarageHorsePowerTrucks = 0;
            int counterCars = 0;
            int counterTrucks = 0;

            foreach (var horsePower in vehicle)
            {
                if (horsePower.Type=="car")
                {
                    avarageHorsePowerCars += horsePower.HorsePower;
                    counterCars++;
                }
                else
                {
                    avarageHorsePowerTrucks += horsePower.HorsePower;
                    counterTrucks++;
                }
                
            }
            avarageHorsePowerCars /= counterCars;
            avarageHorsePowerTrucks /= counterTrucks;

            if (counterCars>0)
            {
                Console.WriteLine($"Cars have average horsepower of: {avarageHorsePowerCars:f2}.");
            }
            else
            {
                Console.WriteLine("Cars have average horsepower of: 0.00.");
            }
            if (counterTrucks>0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {avarageHorsePowerTrucks:f2}.");
            }
            else
            {
                Console.WriteLine("Trucks have average horsepower of: 0.00.");
            }
            


        }

        class Vehicle
        {

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }

    }
}
