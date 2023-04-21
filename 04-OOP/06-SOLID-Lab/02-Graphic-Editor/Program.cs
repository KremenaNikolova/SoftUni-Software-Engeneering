using Models;
using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape = new Circle();
            IShape otherShape = new Rectangle();

            shape.Draw();
            otherShape.Draw();
        }
    }
}
