using System;

namespace _02_Vehicles_Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInformation[1]), double.Parse(carInformation[2]), double.Parse(carInformation[3]));
            Truck truck = new Truck(double.Parse(truckInformation[1]), double.Parse(truckInformation[2]), double.Parse(truckInformation[3]));
            Bus bus = new Bus(double.Parse(busInformation[1]), double.Parse(busInformation[2]), double.Parse(busInformation[3]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] action = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = action[0];
                string type = action[1];
                double distanceOrLitters = double.Parse(action[2]);
                if (command == "Drive")
                {
                    if (type=="Car")
                    {
                        car.Driving(distanceOrLitters);
                    }
                    else if (type=="Truck")
                    {
                        truck.Driving(distanceOrLitters);
                    }
                    else if (type=="Bus")
                    {
                        bus.Driving(distanceOrLitters);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.DriveEmty(distanceOrLitters);
                }
                else if (command == "Refuel")
                {
                    if (type=="Car")
                    {
                        car.Refueling(distanceOrLitters, type);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refueling(distanceOrLitters, type);
                    }
                    else if (type == "Bus")
                    {
                        bus.Refueling(distanceOrLitters, type);
                    }
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

    }
}
