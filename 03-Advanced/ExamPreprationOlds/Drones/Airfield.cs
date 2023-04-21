using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();

            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        //Name: string
        //Capacity: int
        //LandingStrip - double
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }


        public string AddDrone(Drone drone) // adds a drone to the drone's collection if there is room for it. Before adding a drone, check:
        {
            //If the name or brand are null or empty. //If the range is NOT between 5-15 kilometers.
            //If the name, brand, or range properties are not valid, return: "Invalid drone.". 
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            //If the airfield is full (there is no room for more drones), return "Airfield is full.".
            else if (Count >= Capacity)
            {
                return "Airfield is full.";
            }

            //Otherwise, return: "Successfully added {droneName} to the airfield."
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";

        }

        public bool RemoveDrone(string name) // removes a drone by given name, if such exists return true, otherwise false.
        {
            return Drones.Remove(Drones.Find(x => x.Name == name));

        }
        public int RemoveDroneByBrand(string brand) // removes all drones by the given brand, if such exists, return how many drones were removed, otherwise 0.
        {
            return Drones.RemoveAll(x => x.Brand == brand);
        }
        public Drone FlyDrone(string name) //method fly(set its available property to false without removing it from the collection) the drone with the given name if exists.As a result return the drone, or null if does not exist.
        {
            Drone drone = Drones.Find(x=>x.Name == name);
            if (drone!=null)
            {
                drone.Available = false;
            }
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)// method - fly and returns all drones which have a range equal or bigger to the given.Return a list of all drones which have been flown.The range will always be valid.
        {
            List<Drone> droneFly = this.Drones.Where(d => d.Range >= range).ToList();
            foreach (Drone drone in droneFly)
                this.FlyDrone(drone.Name);
            
            return droneFly;
        }

        public string Report() // returns information about the airfield and drones which are not in flight in the following format
        {
            return $"Drones available at {Name}:{Environment.NewLine}{string.Join(Environment.NewLine, Drones.Where(x=>x.Available))}";
        }
    }
}
