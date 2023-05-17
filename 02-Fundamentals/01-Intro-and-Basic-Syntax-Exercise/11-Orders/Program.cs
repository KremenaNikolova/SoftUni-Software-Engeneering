namespace _11_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());

            decimal total = 0;

            for (int i = 0; i < ordersCount; i++)
            {
                decimal capsulePrice = decimal.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                decimal currTotal = (days * capsulesCount) * capsulePrice;
                total += currTotal;
                Console.WriteLine($"The price for the coffee is: ${currTotal:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}