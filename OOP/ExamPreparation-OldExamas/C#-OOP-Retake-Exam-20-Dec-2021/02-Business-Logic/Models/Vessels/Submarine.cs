using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Submarine : Vessel, ISubmarine
    {
        public const double ARMOR_THICKNESS = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, ARMOR_THICKNESS)
        {
            SubmergeMode = false;
        }


        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = ARMOR_THICKNESS;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode==true)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (SubmergeMode==false)
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string submergeMode = SubmergeMode == true ? "ON" : "OFF";

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
