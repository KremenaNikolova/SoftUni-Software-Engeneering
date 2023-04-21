using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int COMFORT = 5;
        private const decimal PRICE = 10;

        public Plant() : base(COMFORT, PRICE)
        {
        }
    }
}
