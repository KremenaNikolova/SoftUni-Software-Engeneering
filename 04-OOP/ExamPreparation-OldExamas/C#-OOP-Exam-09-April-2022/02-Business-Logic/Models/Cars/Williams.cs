using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Cars
{
    public class Williams : FormulaOneCar, IFormulaOneCar
    {
        public Williams(string model, int horsepower, double engineDisplacement) : base(model, horsepower, engineDisplacement)
        {
        }
    }
}
