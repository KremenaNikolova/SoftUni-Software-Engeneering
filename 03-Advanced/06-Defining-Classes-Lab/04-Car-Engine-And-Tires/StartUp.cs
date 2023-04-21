using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(2001, 2.2),
                new Tire(2001, 2.2),
                new Tire(2001, 2.2),
                new Tire(2001, 2.2),
            };

            var engine = new Engine(560, 6300);
            var car = new Car("Seat", "Ibiza", 2011, 50, 5.5, engine, tires);
        }
    }
}
