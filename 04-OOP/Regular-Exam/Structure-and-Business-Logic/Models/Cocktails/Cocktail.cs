using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            switch (Size)
            {
                case "Large": Price = price; break;
                case "Middle": Price = price * 0.6666666666666667; break;
                case "Small": Price = price * 0.3333333333333333; break;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get; private set; } //Possible values: "Small", "Middle", "Large". this.Size will be validated later in the Controller class

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }

        //If the Size is set to "Large", the Price is set to be equal to the passed value
        //If the Size is set to "Middle", the Price is equal to ⅔ of the passed value (example: ⅔ * 13.50 = 9.00)
        //If the Size is set to "Small", the Price is equal to ⅓ of the passed value (example: ⅓ * 10.50 = 3.50)
    }
}
