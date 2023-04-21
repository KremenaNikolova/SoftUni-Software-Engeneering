using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        //Brand - string
        //Cores - int
        //Frequency - double

        public override string ToString()
        {
            return $"{Brand} CPU:" + Environment.NewLine +
                $"Cores: {Cores}" + Environment.NewLine +
                $"Frequency: {Frequency:f1} GHz";
        }
    }
}
