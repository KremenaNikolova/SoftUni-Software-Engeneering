using System;
using System.Collections.Generic;

namespace _06_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> composers = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] composersInfo = Console.ReadLine().Split("|");
                composers.Add(composersInfo[0], new List<string> { composersInfo[1], composersInfo[2] });
            }

            string[] command = Console.ReadLine().Split("|");
            while (command[0]!="Stop")
            {
                string action = command[0];
                switch (action)
                {
                    case "Add":
                        Add(command[1], command[2], command[3], composers);
                        break;
                    case "Remove":
                        Remove(command[1], composers);
                        break;
                    case "ChangeKey":
                        ChangeKey(command[1], command[2], composers);
                        break;
                }

                command = Console.ReadLine().Split("|");
            }
            foreach (var composer in composers)
            {
                Console.WriteLine($"{composer.Key} -> Composer: {composer.Value[0]}, Key: {composer.Value[1]}");
            }
        }

        private static void Add(string piece, string composer, string key, Dictionary<string, List<string>> composers)
        {
            if (composers.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
                return;
            }
            composers.Add(piece,new List<string>{ composer, key});
            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
        }

        private static void Remove(string piece, Dictionary<string, List<string>> composers)
        {
            if (composers.ContainsKey(piece))
            {
                composers.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
                return;
            }
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }

        private static void ChangeKey(string piece, string newKey, Dictionary<string, List<string>> composers)
        {
            if (composers.ContainsKey(piece))
            {
                composers[piece][1]=newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                return;
            }
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }
}
