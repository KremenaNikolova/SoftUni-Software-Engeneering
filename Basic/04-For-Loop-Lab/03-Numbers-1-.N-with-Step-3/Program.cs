using System;

namespace _03_Numbers_1_.N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
