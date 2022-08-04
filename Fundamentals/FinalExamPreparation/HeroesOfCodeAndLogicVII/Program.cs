using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());

            Dictionary<string, Hero> heroesStats = new Dictionary<string, Hero>();

            for (int i = 0; i < partySize; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                if (!heroesStats.ContainsKey(heroName))
                {
                    heroesStats[heroName] = new Hero();
                }

                heroesStats[heroName] = new Hero()
                {
                    HealthPoints = hp,
                    ManaPoints = mp
                };

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = commands[0];
                string heroName = commands[1];
                switch (cmd)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        foreach (var hero in heroesStats)
                        {
                            if (hero.Key == heroName)
                            {
                                if (hero.Value.ManaPoints >= mpNeeded)
                                {
                                    hero.Value.ManaPoints -= mpNeeded;
                                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero.Value.ManaPoints} MP!");
                                }
                                else
                                {
                                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                                }
                            }
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];


                        heroesStats[heroName].TakeDamage(damage);


                        if (heroesStats[heroName].HealthPoints > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesStats[heroName].HealthPoints} HP left!");
                        }
                        else
                        {
                            heroesStats.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        int amountOfMana = int.Parse(commands[2]);

                        heroesStats[heroName].Recharge(amountOfMana, heroName);
                        break;
                    case "Heal":
                        int amountOfHealth = int.Parse(commands[2]);
                        heroesStats[heroName].Heal(amountOfHealth, heroName);

                        break;
                }

            }

            foreach (var hero in heroesStats)
            {
                Console.WriteLine($"{hero.Key}\n  HP: {hero.Value.HealthPoints}\n  MP: {hero.Value.ManaPoints}");
            }
        }
    }

    class Hero
    {


        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }

        public int TakeDamage(int damage)
        {
            this.HealthPoints -= damage;


            return this.HealthPoints;

        }

        public void Recharge(int amountOfMana, string heroName)
        {
            if (this.ManaPoints + amountOfMana > 200)
            {
                Console.WriteLine($"{heroName} recharged for {200 - this.ManaPoints} MP!");
                this.ManaPoints = 200;

            }
            else
            {
                this.ManaPoints += amountOfMana;
                Console.WriteLine($"{heroName} recharged for {amountOfMana} MP!");
            }
        }

        public void Heal(int amountOfHealth, string heroName)
        {
            if (this.HealthPoints + amountOfHealth > 100)
            {
                Console.WriteLine($"{heroName} healed for {100 - this.HealthPoints} HP!");
                this.HealthPoints = 100;
            }
            else
            {
                this.HealthPoints += amountOfHealth;
                Console.WriteLine($"{heroName} healed for {amountOfHealth} HP!");
            }
        }
    }
}
