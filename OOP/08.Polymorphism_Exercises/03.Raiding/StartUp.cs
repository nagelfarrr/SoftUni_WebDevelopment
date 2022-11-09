namespace Raiding
{
    using System;
    using System.Collections.Generic;

    using Factory;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<BaseHero> raidParty = new HashSet<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (raidParty.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = HeroFactory.GetHero(heroName, heroType);
                    raidParty.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());
            int heroesDmg = 0;

            foreach (var hero in raidParty)
            {
                Console.WriteLine(hero.CastAbility());
                heroesDmg += hero.Power;
            }

            if (heroesDmg >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
