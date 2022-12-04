using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vesselsList;

        public Captain(string fullName)
        {
            FullName= fullName;

            vesselsList = new List<IVessel>();
            combatExperience= 0;
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience => combatExperience;

        public ICollection<IVessel> Vessels => vesselsList;

        public void AddVessel(IVessel vessel)
        {
            if (vessel==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            vesselsList.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            foreach (var vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
