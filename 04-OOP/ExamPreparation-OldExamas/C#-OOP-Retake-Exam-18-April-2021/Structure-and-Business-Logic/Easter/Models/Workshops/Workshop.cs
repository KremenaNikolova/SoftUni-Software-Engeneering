using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy>0 && bunny.Dyes.Where(x=>x.Power>0).Count()>0 &&!egg.IsDone())
            {
                var dye = bunny.Dyes.FirstOrDefault(x=>x.Power>0);

                while (bunny.Energy > 0 && dye.Power > 0 && !egg.IsDone())
                {
                    dye.Use();
                    bunny.Work();
                    egg.GetColored();
                }
            }
        }
    }
}
