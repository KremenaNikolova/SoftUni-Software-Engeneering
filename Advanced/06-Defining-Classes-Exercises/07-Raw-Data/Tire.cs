using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Raw_Data
{
    public class Tire
    {
        private int age;
        private float pressure;

        public Tire (float pressure, int age)
        {
            Pressure= pressure;
            Age= age;
        }

        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
