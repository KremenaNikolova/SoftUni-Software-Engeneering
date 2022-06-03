using System;

namespace _02_Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            //                    Мorning                Afternoon           Evening
            //10 <= градуси <= 18 Outfit = Sweatshirt  Outfit = Shirt      Outfit = Shirt
            //                    Shoes = Sneakers     Shoes = Moccasins   Shoes = Moccasins
            //   
            //18 < градуси <= 24  Outfit = Shirt       Outfit = T - Shirt  Outfit = Shirt
            //                    Shoes = Moccasins    Shoes = Sandals     Shoes = Moccasins
            //
            //градуси >= 25       Outfit = T - Shirt   Outfit = Swim Suit  Outfit = Shirt
            //                    Shoes = Sandals      Shoes = Barefoot    Shoes = Moccasins
            if (degrees >= 10 && degrees <= 18)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                        break;
                    case "Afternoon":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Afternoon":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }

            }
            else if (degrees >= 25)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Afternoon":
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            //Да се отпечата на конзолата на един ред: "It's {градуси} degrees, get your {облекло} and {обувки}."
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
 
