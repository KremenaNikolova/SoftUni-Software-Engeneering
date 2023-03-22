namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
            PartsCars = new HashSet<PartCar>();
        }
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<PartCar> PartsCars { get; set; }
    }
}
