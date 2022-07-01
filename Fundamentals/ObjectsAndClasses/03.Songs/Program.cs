using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] input = Console.ReadLine().Split("_").ToArray();
                Song song = new Song();
                song.TypeList = input[0];
                song.Name = input[1];
                song.Time = input[2];

                songs.Add(song);
            }

            string command = Console.ReadLine();
            foreach (var song in songs)
            {
                if (song.TypeList == command)
                {
                    Console.WriteLine(song.Name);
                }
                else if (command == "all")
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    public class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }

    }
}