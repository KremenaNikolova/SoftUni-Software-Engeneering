using System;
using System.Collections.Generic;
using System.Linq;

namespace _1ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            ListyIterator<string> elements = new ListyIterator<string>(input);

            string command = Console.ReadLine();

            while (command!="END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(elements.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(elements.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            elements.Print();
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }
                command = Console.ReadLine();
            }


        }
    }
}
