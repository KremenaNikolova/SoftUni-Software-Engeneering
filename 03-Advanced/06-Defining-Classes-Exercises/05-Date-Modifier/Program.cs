using System;

namespace _05_Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime lastDate = DateTime.Parse(Console.ReadLine());

            DateModifier calculation = new DateModifier(firstDate, lastDate);
            calculation.FirstDate = firstDate;
            calculation.LastDate = lastDate;

            Console.WriteLine(Math.Abs(calculation.Calculator()));
        }
    }
}
