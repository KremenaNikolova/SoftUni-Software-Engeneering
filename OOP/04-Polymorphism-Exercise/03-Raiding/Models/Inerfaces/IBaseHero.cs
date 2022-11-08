namespace Raiding.Models.Inerfaces
{
    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }
        string CastAbility();
    }
}
