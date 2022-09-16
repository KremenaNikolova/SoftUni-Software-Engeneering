using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            List<string> copyOfSongs = new List<string>(songs);
            Queue<string> playlist = new Queue<string>(songs);

            

            while (playlist.Count > 0)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                if (action == "Play")
                {
                    copyOfSongs.Remove(playlist.Dequeue());
                }
                else if (action == "Add")
                {
                    string song = String.Join(" ", command.Skip(1)); //add songs of songs
                    if (!copyOfSongs.Contains(song))               //01234
                    {
                        playlist.Enqueue(song);
                        copyOfSongs.Add(song);
                        continue;
                    }
                    Console.WriteLine($"{song} is already contained!");
                }
                else if (action == "Show")
                {
                    Console.WriteLine(String.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
