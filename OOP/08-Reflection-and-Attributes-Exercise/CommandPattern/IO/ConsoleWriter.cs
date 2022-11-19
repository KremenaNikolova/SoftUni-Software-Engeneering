using CommandPattern.IO.Contracts;
using System;

namespace CommandPattern.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value) 
        {
            Console.Write(value.ToString());
        }
            

        public void WriteLine(object value)
        {
            Console.WriteLine(value.ToString());
        }
    }
}
