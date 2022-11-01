using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Dough
    {

        private Dictionary<string, double> doughInformation = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 },
        };

        private string flourType; //white or wholegrain
        private string bakingTechnique; //cryspy, chewy or homemade
        private double doughWeight;

        public Dough(string flourType, string bakingTechnique, double doughWeight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            DoughWeight = doughWeight;
        }

        public string FlourType 
        {
            get { return flourType; }
            private set
            {
                if (!doughInformation.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get { return bakingTechnique; }
            private set
            {
                if (!doughInformation.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double DoughWeight 
        {
            get { return doughWeight; }
            private set
            {
                if (value<1 || value>200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                doughWeight = value;
            }
        }

        public double DoughCalories =>2 *doughWeight* doughInformation[FlourType.ToLower()]* doughInformation[BakingTechnique.ToLower()];

        //calories formula: 2*weight*flourType*bakingTechnique
    }
}
