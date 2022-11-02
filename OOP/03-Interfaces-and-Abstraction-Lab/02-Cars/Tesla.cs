using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla: IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public void Star()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
