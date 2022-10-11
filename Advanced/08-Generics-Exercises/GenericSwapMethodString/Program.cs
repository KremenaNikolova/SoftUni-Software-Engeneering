using System;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.List.Add(input);
            }

            int[] swapIndexes = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int first=swapIndexes[0];
            int second=swapIndexes[1];

            string firstNameIndexCopy = box.List[first];

            box.List[first]=box.List[second];
            box.List[second] = firstNameIndexCopy;

            Console.WriteLine(box);
        }
    }
}
