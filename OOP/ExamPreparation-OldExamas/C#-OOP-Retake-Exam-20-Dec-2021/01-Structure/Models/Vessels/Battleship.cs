using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel, IBattleship
    {
        public const double ARMOR_THICKNESS = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, ARMOR_THICKNESS)
        {
            SonarMode= false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = ARMOR_THICKNESS;
        }

        public void ToggleSonarMode()
        {
            if (SonarMode==true)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if (SonarMode==false)
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
            SonarMode = !SonarMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string sonarMode = SonarMode == true ? "ON" : "OFF";

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
