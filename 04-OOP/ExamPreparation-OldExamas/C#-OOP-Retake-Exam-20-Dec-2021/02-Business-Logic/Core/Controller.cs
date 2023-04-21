using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NavalVesselsBusinessLogic.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vesselRepository;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }


        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.FirstOrDefault(x => x.FullName == fullName) != null)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name); //change vesselType 
            }

            IVessel vessel;
            switch (vesselType)
            {
                case "Submarine": vessel = new Submarine(name, mainWeaponCaliber, speed); break;
                case "Battleship": vessel = new Battleship(name, mainWeaponCaliber, speed); break;
                default: return OutputMessages.InvalidVesselType;
            }

            vesselRepository.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            var vessel = vesselRepository.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain= captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);
            return vessel?.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submrine = (Submarine)vessel;
                submrine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vesselRepository.FindByName(attackingVesselName);
            var defendingVessel = vesselRepository.FindByName(defendingVesselName);

            if (attackingVessel == null || defendingVessel == null)
            {
                string outputVesselName = attackingVessel == null ? attackingVesselName : defendingVesselName;

                return string.Format(OutputMessages.VesselNotFound, outputVesselName);
            }
            if (attackingVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
            {
                string outputVesselMesssage = attackingVessel.ArmorThickness == 0 ? attackingVesselName : defendingVesselName;

                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, outputVesselMesssage);
            }
            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }






    }
}
