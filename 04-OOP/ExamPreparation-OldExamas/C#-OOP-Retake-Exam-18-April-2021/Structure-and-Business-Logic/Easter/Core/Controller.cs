using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Workshops;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;
        int countColoredEggs = 0;
        
        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            switch (bunnyType)
            {
                case "HappyBunny": bunny = new HappyBunny(bunnyName); break;
                case "SleepyBunny":bunny = new SleepyBunny(bunnyName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var orderedBunnies = bunnies.Models.Where(x=>x.Energy>=50).Where(x=>x.Dyes.Any(y=>y.Power>0)).OrderByDescending(x => x.Energy);
            if (!orderedBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            var bunny = orderedBunnies.FirstOrDefault();
            IEgg egg = eggs.FindByName(eggName);

            Workshop workshop = new Workshop();
            workshop.Color(egg, bunny);
            if (bunny.Energy==0)
            {
                bunnies.Remove(bunny);
            }
            if (egg.IsDone())
            {
                countColoredEggs++;
            }

            string eggResult = egg.IsDone() ? string.Format(OutputMessages.EggIsDone, eggName) : string.Format(OutputMessages.EggIsNotDone, eggName);
            return eggResult;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x=>x.IsFinished()==false).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
