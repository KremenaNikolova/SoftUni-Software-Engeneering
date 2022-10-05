using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Raw_Data
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
