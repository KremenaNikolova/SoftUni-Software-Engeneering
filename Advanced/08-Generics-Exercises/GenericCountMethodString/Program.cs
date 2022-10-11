using System;

namespace GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                box.Items.Add(Console.ReadLine());
            }

            string compareWord = Console.ReadLine();

            Console.WriteLine(box.Compare(compareWord));

            
        }
    }
}
