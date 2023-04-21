using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("kremena");
            randomList.Add("valerieva");
            randomList.Add("nikolova");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
