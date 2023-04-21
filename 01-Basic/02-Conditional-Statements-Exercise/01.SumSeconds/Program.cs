using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsFirst = int.Parse(Console.ReadLine());
            int secondsSecond = int.Parse(Console.ReadLine());
            int secondsThird = int.Parse(Console.ReadLine());

            int total = secondsFirst + secondsSecond + secondsThird;
            int minutes = total / 60;
            int seconds = total % 60;

            if (seconds <10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }

        }
    }
}
//Да се напише програма, която чете времената на състезателите в секунди, въведени от
//потребителя и пресмята сумарното им време във формат "минути:секунди".
//Секундите да се изведат с водеща нула (2  "02", 7  "07", 35  "35"). 