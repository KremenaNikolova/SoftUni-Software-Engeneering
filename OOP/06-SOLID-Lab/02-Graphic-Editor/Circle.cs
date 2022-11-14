using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Circle");
        }
    }
}
