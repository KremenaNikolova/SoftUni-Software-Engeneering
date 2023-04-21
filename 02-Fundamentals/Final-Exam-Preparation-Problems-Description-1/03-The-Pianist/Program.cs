using System;
using System.Collections.Generic;

namespace _03_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            Dictionary<string, string> piecesComposer = new Dictionary<string, string>();
            Dictionary<string, string> piecesKey = new Dictionary<string, string>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                piecesComposer.Add(input[0], input[1]);
                piecesKey.Add(input[0], input[2]);
            }
            string[] command = Console.ReadLine().Split("|");
            while (command[0]!="Stop")
            {
                string cmd = command[0];

                if (cmd =="Add")
                {
                    string piece = command[1];
                    string composer = command[2];
                    string key = command[3];
                    if (!piecesComposer.ContainsKey(piece))
                    {
                        piecesComposer.Add(piece, composer);
                        piecesKey.Add(piece, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (cmd == "Remove")
                {
                    string piece = command[1];
                    if (!piecesComposer.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        piecesComposer.Remove(piece);
                        piecesKey.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (cmd =="ChangeKey")
                {
                    string piece = command[1];
                    string newKey = command[2];
                    if (!piecesComposer.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        piecesKey[piece] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                }

                command = Console.ReadLine().Split("|");

            }
            foreach (var piececomb in piecesComposer)
            {
                foreach (var piecekey in piecesKey)
                {
                    if (piececomb.Key == piecekey.Key)
                    {
                        Console.WriteLine($"{piecekey.Key} -> Composer: {piececomb.Value}, Key: {piecekey.Value}");
                    }
                }
            }
        }
    }
}
