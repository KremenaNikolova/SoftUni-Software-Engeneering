using System;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                box.List.Add(double.Parse(Console.ReadLine()));
            }

            double compareNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareCount(compareNumber));
        }
    }
}
