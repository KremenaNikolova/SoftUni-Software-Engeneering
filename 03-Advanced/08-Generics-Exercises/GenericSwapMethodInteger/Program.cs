using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.List.Add(input);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            int copyOfFirst = box.List[firstIndex];
            box.List[firstIndex] = box.List[secondIndex];
            box.List[secondIndex] = copyOfFirst;

            Console.WriteLine(box);
        }
    }
}
