using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] commands = input.Split(' ');
                string cmd = commands[0];
                string heroName = commands[1];
                
                
                switch (cmd)
                {
                    case "Enroll":
                        if (!heroes.ContainsKey(heroName))
                        {
                            heroes[heroName] = new Hero();
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} is already enrolled.");
                        }

                        heroes[heroName].Spells = new List<string>();
                        break;
                    case "Learn":
                        string spellToLearn = commands[2];

                        LearnSpell(heroes, heroName, spellToLearn);
                        break;
                    case "Unlearn":
                        string spellToUnlearn = commands[2];

                        UnlearnSpell(heroes, heroName, spellToUnlearn);
                        break;
                }
            }

            Console.WriteLine("Heroes:");
            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value.Spells)}");
            }
        }

        private static void UnlearnSpell(Dictionary<string, Hero> heroes, string heroName, string spellToUnlearn)
        {
            if (!heroes.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
                return;
            }

            if (!heroes[heroName].Spells.Contains(spellToUnlearn))
            {
                Console.WriteLine($"{heroName} doesn't know {spellToUnlearn}.");
            }
            else
            {
                heroes[heroName].UnlearnSpell(spellToUnlearn);
            }
        }

        private static void LearnSpell(Dictionary<string, Hero> heroes, string heroName, string spellToLearn)
        {
            if (!heroes.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
                return;
            }

            if (heroes[heroName].Spells.Contains(spellToLearn))
            {
                Console.WriteLine($"{heroName} has already learnt {spellToLearn}.");
            }
            else
            {
                heroes[heroName].LearnSpell(spellToLearn);
            }
        }
    }

    class Hero
    {
        public Hero()
        {
            this.Spells = new List<string>();
        }

        public List<string> Spells { get; set; }

        public void LearnSpell(string spellToLearn)
        {
           this.Spells.Add(spellToLearn);
        }

        public void UnlearnSpell(string spellToUnlearn)
        {
            this.Spells.Remove(spellToUnlearn);
        }
    }
}
