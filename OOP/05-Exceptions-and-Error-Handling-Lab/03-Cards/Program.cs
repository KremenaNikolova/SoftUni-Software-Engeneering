using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03_Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputCards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < inputCards.Length; i++)
            {
                string[] currCard = inputCards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = currCard[0];
                string suit = currCard[1];
                try
                {
                    cards.Add(ValidadeCards(face,suit));
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ",cards));



        }
        static Card ValidadeCards(string face, string suit)
        {
            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[] { "S", "H", "D", "C" };

            if (!validFaces.Contains(face) || !validSuits.Contains(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            string UTF = string.Empty;
            switch (suit)
            {
                case "S": UTF = "\u2660"; break;
                case "H": UTF = "\u2665"; break;
                case "D": UTF = "\u2666"; break;
                case "C": UTF = "\u2663"; break;
            }

            return new Card(face, UTF);
        }





    }

    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        //hold card's fase and suit
        //Valid card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
        //Valid card suits are: S (♠), H (♥), D (♦), C (♣)


        public string Face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
            //"[{face}{suit}]" – example: [A♠] [5♣] [10♦]
        }
    }


}

