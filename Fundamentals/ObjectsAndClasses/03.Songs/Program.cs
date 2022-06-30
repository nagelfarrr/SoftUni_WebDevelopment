namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] input = Console.ReadLine().Split("_").ToArray();
                Song song = new Song();
                song.TypeList = input[0];
                song.Name = input[1];
                song.Time = input[2];


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