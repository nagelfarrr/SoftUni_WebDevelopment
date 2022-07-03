using System;

namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rndm = new Random();
            string[] phrases =
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.", "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events =
            {
                "Now I feel good.", 
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", 
                "I feel great!"
            };
            string[] authors =
            {
                "Diana",
                "Petya",
                "Stella", 
                "Elena", 
                "Katya", 
                "Iva", 
                "Annie", 
                "Eva"
            };
            string[] cities =
            {
                "Burgas", 
                "Sofia", 
                "Plovdiv", 
                "Varna", 
                "Ruse"
            };
            int numberOfMessages = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfMessages; i++)
            {
                int randomPhrase = rndm.Next(phrases.Length);
                int randomEvent = rndm.Next(events.Length);
                int randomAuthor = rndm.Next(authors.Length);
                int randomCity = rndm.Next(cities.Length);

                Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} - {cities[randomCity]}");
            }

        }
    }
}
