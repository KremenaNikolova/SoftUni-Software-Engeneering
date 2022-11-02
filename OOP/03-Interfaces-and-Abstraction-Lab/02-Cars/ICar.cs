using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        string Model { get;}
        string Color { get; }

        public void Star();
        public void Stop();
    }
}
