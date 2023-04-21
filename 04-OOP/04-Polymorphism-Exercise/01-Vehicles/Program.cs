using System;

namespace _01_Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicles car = new Car(double.Parse(carInformation[1]), double.Parse(carInformation[2]));
            Vehicles truck = new Truck(double.Parse(truckInformation[1]), double.Parse(truckInformation[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] action = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = action[0];
                string carOrTruck = action[1];
                double distanceOrLitters = double.Parse(action[2]);

                if (command == "Drive")
                {
                    if (carOrTruck=="Car")
                    {
                        car.Driving(distanceOrLitters);
                    }
                    else
                    {
                        truck.Driving(distanceOrLitters);
                    }
                }
                else if (command== "Refuel")
                {
                    if (carOrTruck=="Car")
                    {
                        car.Refueling(distanceOrLitters);
                    }
                    else
                    {
                        truck.Refueling(distanceOrLitters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
