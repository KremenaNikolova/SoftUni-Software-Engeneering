using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> example = new EqualityScale<int>(5,5);

            Console.WriteLine(example.AreEqual());
        }
    }
}
