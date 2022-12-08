using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int COMFORT = 1;
        private const decimal PRICE = 5;

        public Ornament() : base(COMFORT, PRICE)
        {
        }
    }
}
