//There is a party in SoftUni.Many guests are invited and there are two types of them: VIP and Regular. When a guest comes, check if he/she exists in any of the two reservation lists.
//All reservation numbers will be with the length of 8 chars.
//All VIP numbers start with a digit.
//First, you will be receiving the reservation numbers of the guests. You can also receive 2 possible commands:
//•	"PARTY" – After this command, you will begin receiving the reservation numbers of the people, who came to the party.
//•	"END" – The party is over and you have to stop the program and print the appropriate output.
//In the end, print the count of the guests who didn't come to the party, and afterward, print their reservation numbers. the VIP guests must be first.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string number;
            while ((number = Console.ReadLine()) != "PARTY") 
            {
                //string numberOfQuests = number;
                if (number.Length==8)
                {
                    guests.Add(number);
                }
            }
            string guestsOnTheParty;
            while ((guestsOnTheParty=Console.ReadLine()) != "END")
            {
                //string comingToParty = guestsOnTheParty;
                if (guests.Contains(guestsOnTheParty))
                {
                    guests.Remove(guestsOnTheParty);
                }
            }
            Console.WriteLine(guests.Count);
            foreach (string guest in guests.Where(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
            foreach (string guest in guests.Where(x => char.IsLetter(x[0])))
            {
                Console.WriteLine(guest);
            }

            
        }
    }
}
