using System;

namespace _08_Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMoedel = int.Parse(Console.ReadLine());
            string theBigestKeg = " ";
            double oldVolumeOfTheKeg = 0;

            for (int i = 0; i < numberOfMoedel; i++)
            {
                string modelOfTheKeg = Console.ReadLine();
                float radiusOfTheKeg = float.Parse(Console.ReadLine());
                int heightOfTheKeg = int.Parse(Console.ReadLine());
                double newVolumeOfTheKeg = Math.PI * Math.Pow(radiusOfTheKeg,2) * heightOfTheKeg;
                if (oldVolumeOfTheKeg<newVolumeOfTheKeg)
                {
                    oldVolumeOfTheKeg = newVolumeOfTheKeg;
                    theBigestKeg = modelOfTheKeg;
                
                }
            }
            Console.WriteLine(theBigestKeg);
            


        }
    }
}
