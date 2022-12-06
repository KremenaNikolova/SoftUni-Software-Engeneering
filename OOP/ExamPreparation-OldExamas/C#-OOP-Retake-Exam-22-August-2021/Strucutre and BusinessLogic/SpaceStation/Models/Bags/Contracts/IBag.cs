namespace SpaceStation.Models.Bag.Contracts
{
    using System.Collections.Generic;

    public interface IBag
    {
        ICollection<string> Items { get; }
    }
}
