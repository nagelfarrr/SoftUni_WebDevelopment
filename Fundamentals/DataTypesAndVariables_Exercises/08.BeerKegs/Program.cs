using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            string biggestKeg = string.Empty;
            double biggestKegVolume = 0;
            for (int i = 0; i < nLines; i++)
            {
                string kegModel = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume = (Math.PI * kegRadius * kegRadius * kegHeight);

                if (kegVolume > biggestKegVolume)
                {
                    biggestKeg = kegModel;
                    biggestKegVolume = kegVolume;
                }

            }
            Console.WriteLine(biggestKeg);

        }
    }
}
