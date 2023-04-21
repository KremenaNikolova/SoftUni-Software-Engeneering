using Raiding.Models.Inerfaces;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public abstract string Name { get; set; }
        public abstract int Power {get; set;}

        public abstract string CastAbility();
    }
}
