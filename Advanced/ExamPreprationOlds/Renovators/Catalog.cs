using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();

            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator) //adds a renovator to the catalog's collection, if renovators are still needed. Before adding a renovator, check:
        {
            //If the name or specialty are null or empty, return "Invalid renovator's information.".
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            //If renovators are no more needed, return "Renovators are no more needed.".Renovators are needed when the count of the added renovators is  less      than      the  NeededRenovators property of the Catalog.
            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            //If the rate is above 350 BGN, return "Invalid renovator's rate."

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            //Otherwise, return: "Successfully added {renovatorName} to the catalog."
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name) // removes a renovator by given name.
        {
            //If such exists returns true;
            //Otherwise, returns false.

            return renovators.Remove(renovators.Find(r => r.Name == name));

        }

        public int RemoveRenovatorBySpecialty(string type) // removes all renovators by the given specialty.
        {
            //If such exist(s), returns the count of the removed renovators;
            //Otherwise, returns 0.
                return renovators.RemoveAll(r => r.Type == type);
        }

        public Renovator HireRenovator(string name) //method - hire (set their available property to true without removing them from the collection) the renovator with the given name, if they exist. As a result, return the renovator, or null, if they don't exist.
        {
            if (renovators.Any(r => r.Name == name))
            {
                Renovator renovator = renovators.Find(r => r.Name == name);
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)// method – return a list with all renovators that have been working for days days or more.
        {
            return renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report() // returns a string with information about the catalog and renovators who are not hired in the following format:
        {
            return $"Renovators available for Project {Project}:" + Environment.NewLine + string.Join(Environment.NewLine, renovators.Where(r=>!r.Hired)).Trim();
            //"Renovators available for Project {project}:
            //{Renovator1}
            //{Renovator2}
            //{…}"
        }


    }
}
