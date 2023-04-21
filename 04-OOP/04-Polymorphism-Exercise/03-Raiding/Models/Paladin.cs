namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            Name = name;
            Power = 100;
        }

        public override string Name {get; set;}
        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
