using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long pokePower = long.Parse(Console.ReadLine());
            long distance = long.Parse(Console.ReadLine());
            int exhaustionFactory = int.Parse(Console.ReadLine());
            double fiftypercent = pokePower * 0.5;
            //distance - power until power is less than distance - not enough power to reach the next target
            //successful poke at every substract -- counter needed
            //if power == 50%power -- power/exhastionfactory(if its possible) else continue substracting eitherway
            int counter = 0;
            while (distance <= pokePower)
            {
                pokePower -= distance;
                counter++;
                if (pokePower == fiftypercent && exhaustionFactory != 0)
                {
                    pokePower = pokePower / exhaustionFactory;
                }


            }

            Console.WriteLine(pokePower);
            Console.WriteLine(counter);
        }
    }
}
