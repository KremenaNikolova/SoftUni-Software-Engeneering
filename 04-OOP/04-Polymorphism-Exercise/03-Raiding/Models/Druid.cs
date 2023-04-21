using System;
using System.Runtime.CompilerServices;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
        {
            Name = name;
            Power = 80;
        }

        public override string Name {get; set;}
        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
