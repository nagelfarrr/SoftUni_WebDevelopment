using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.SongQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> playlist = new Queue<string>(songs);

            while (playlist.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(' ');

                switch (commands[0])
                {
                    case "Play":
                        playlist.Dequeue();
                        break;

                    case "Add":
                        string songName = string.Join(" ",commands);
                        songName = songName.Substring(4);
                        if (!playlist.Contains(songName))
                        {
                            playlist.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ",playlist));
                        break;
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
