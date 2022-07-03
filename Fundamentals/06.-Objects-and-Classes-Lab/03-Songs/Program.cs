using System;
using System.Collections.Generic;

namespace _03_Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> saveSongsInList = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split('_');

                Song newSong = new Song();

                newSong.TypeList = data[0];
                newSong.NameOfSong = data[1];
                newSong.Time = data[2];

                saveSongsInList.Add(newSong);
            }
            string typeOfTheList = Console.ReadLine();

            if (typeOfTheList=="all")
            {
                foreach (Song song in saveSongsInList)
                {
                    Console.WriteLine(song.NameOfSong);
                }
            }
            else
            {
                foreach (Song song in saveSongsInList)
                {
                    if (typeOfTheList==song.TypeList)
                    {
                        Console.WriteLine(song.NameOfSong);
                    }
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string NameOfSong { get; set; }
        public string Time { get; set; }
    }
}

