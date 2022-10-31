using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Class_Box_Data
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                else
                {
                    lenght = value;
                }
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                else
                {
                    width = value;
                }
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                else
                {
                    height = value;
                }
            }
        }


        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * (lenght * width + lenght * height + width * height);
        }
        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2*(lenght*height + width*height);
        }
        public double Volume()
        {
            //Volume = lwh
            return lenght * width * height;
        }
    }
}
