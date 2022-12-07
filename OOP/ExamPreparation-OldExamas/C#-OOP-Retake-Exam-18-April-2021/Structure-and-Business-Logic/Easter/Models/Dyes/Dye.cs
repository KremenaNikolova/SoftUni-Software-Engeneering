using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value<0)
                {
                    value = 0;
                }
                power = value;
            }
        }


        public void Use()
        {
            Power -= 10;
        }
        public bool IsFinished()
        {
            return power== 0;
        }

    }
}
