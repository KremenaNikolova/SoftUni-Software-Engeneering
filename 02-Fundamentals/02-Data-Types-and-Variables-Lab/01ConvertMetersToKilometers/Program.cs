﻿using System;

namespace _01ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
