using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier()
            {
                FirstDate = firstDate,
                SecondDate = secondDate
            };

            Console.WriteLine(dateModifier.DayDifferences(firstDate,secondDate));
        }
    }
}
