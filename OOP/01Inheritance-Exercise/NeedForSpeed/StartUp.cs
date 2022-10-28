namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(320, 45.5);
            vehicle.Drive(20);
            System.Console.WriteLine(vehicle.Fuel);

            Car car = new Car(320, 45.5);
            car.Drive(20);
            System.Console.WriteLine(car.Fuel);
        }
    }
}
