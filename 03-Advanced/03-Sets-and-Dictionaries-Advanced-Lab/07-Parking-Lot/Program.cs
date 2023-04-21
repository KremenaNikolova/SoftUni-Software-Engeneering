//Create a program that:
//•	Records a car number for every car that enters the parking lot.
//•	Removes a car number when the car leaves the parking lot.
//The input will be a string in the format: "direction, carNumber".You will be receiving commands until the "END" command is given.
//Print the car numbers of the cars, which are still in the parking lot:


using System;
using System.Collections.Generic;

namespace _07_Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] token = input.Split(", ");
                string command = token[0];
                string car = token[1];
                if (command=="IN")
                {
                    cars.Add(car);
                }
                else
                {
                    cars.Remove(car);
                }

                input = Console.ReadLine();
            }

            if (cars.Count>0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
