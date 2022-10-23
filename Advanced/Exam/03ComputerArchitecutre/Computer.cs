using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Multiprocessor = new List<CPU>();

            Model = model;
            Capacity = capacity;
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu) // adds an entity to the multiprocessor if there is room for it.If there is no room for another CPU, skip the command
        {
            if (Count<Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand) // removes a CPU by a given brand.If such exists, returns true, otherwise, returns false.
        {
            return Multiprocessor.Remove(Multiprocessor.Find(x => x.Brand == brand));
        }
        public CPU MostPowerful() // returns the most powerful CPU(the CPU with the highest frequency)
        {
            return Multiprocessor.OrderByDescending(x=>x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand) // returns the CPU with the given brand.If there is no CPU, meeting the requirements, return null
        {
            return Multiprocessor.Find(x => x.Brand == brand);
        }
        public string Report()
        {
            return $"CPUs in the Computer {Model}:{Environment.NewLine}{string.Join(Environment.NewLine, Multiprocessor)}";
        }

    }
}
