namespace Heroes.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Repositories.Contracts;

    public class Controller :IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            string[] heroTypes = new string[] { "Knight", "Barbarian" };
            if (!heroTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = null;
            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon = null;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
                
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }
        
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(h => h.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (!weapons.Models.Any(w => w.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            var hero = heroes.FindByName(heroName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {hero.Name} is well-armed.");
            }

            var weapon = weapons.FindByName(weaponName);

            hero.AddWeapon(weapon);

            return $"Hero {hero.Name} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> players = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(players);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models
                         .OrderBy(x => x.GetType().Name)
                         .ThenByDescending(x => x.Health)
                         .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.Append("--Weapon: ");
                sb.AppendLine(hero.Weapon == null ? "Unarmed" : hero.Weapon.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
