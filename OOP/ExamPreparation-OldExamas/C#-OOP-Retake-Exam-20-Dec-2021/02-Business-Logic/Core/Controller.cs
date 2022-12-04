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
        private IRepository<IVessel> vesselRepository;
        private ICollection<ICaptain> captains;

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
            if (vesselRepository.FindByName(name)!=null) 
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
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
            throw new NotImplementedException();
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            throw new NotImplementedException();
        }

        public string CaptainReport(string captainFullName)
        {
            throw new NotImplementedException();
        }



        public string ServiceVessel(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string VesselReport(string vesselName)
        {
            throw new NotImplementedException();
        }
    }
}
