using System;

namespace _01_Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string result = age <= 2 ? "baby" : age > 2 && age <= 13 ? "adult" : age > 13 && age <= 19 ? "tennager" : age > 19 && age <= 65 ? "adult" : "elder";

            Console.WriteLine(result);
            //    if (age <= 0 && age <= 2)
            //    {
            //        Console.WriteLine("baby");
            //    }
            //    else if (age > 2 && age <=13)
            //    {
            //        Console.WriteLine("child");
            //    }
            //    else if (age>13 && age<=19)
            //    {
            //        Console.WriteLine("teenager");
            //    }
            //    else if (age>19 && age<=65)
            //    {
            //        Console.WriteLine("adult");
            //    }
            //    else
            //    {
            //        Console.WriteLine("elder");
            //    }
        }
    }
}
