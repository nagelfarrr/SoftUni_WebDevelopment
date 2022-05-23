using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine()) * (lostGames / 2);
            double mousePrice = double.Parse(Console.ReadLine()) * (lostGames / 3);
            double keyboardPrice = double.Parse(Console.ReadLine()) * (lostGames / 6);
            double displayPrice = double.Parse(Console.ReadLine()) * (lostGames / 12);

            //int trashedHeadsets = lostGames / 2;
            // int trashedMouses = lostGames / 3;
            //int trashedKeyboards = lostGames / 6;
            //int trashedDisplays = lostGames / 12;

            double price = headsetPrice + mousePrice + keyboardPrice + displayPrice;
            Console.WriteLine($"Rage expenses: {price:f2} lv.");
        }
    }
}
