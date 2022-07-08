using System;
using System.Collections.Generic;

namespace _06_Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            //List<Trucks> trucks = new List<Trucks>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];

                if (type == "End")
                {
                    break;
                }
                string model = input[1];
                string color= input[2];
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
                    return;
                }
                else 
                {
                    foreach (var item in collection)
                    {

                    }
                }
            }


        }

        class Vehicle
        {

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }

        //class Trucks
        //{
        //    public string Type { get; set; }
        //    public string Model { get; set; }
        //    public string Color { get; set; }
        //    public int HorsePower { get; set; }
        //}
    }
}
