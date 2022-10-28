using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Keks");


            Console.WriteLine($"name: {cake.Name}, price: {cake.Price}, grams: {cake.Grams}, calories: {cake.Calories}");
        }
    }
}