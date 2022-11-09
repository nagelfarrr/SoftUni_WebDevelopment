﻿namespace Raiding.Factory
{
    using System;

    using Models;

    public class HeroFactory
    {
        public static BaseHero GetHero(string name, string type)
        {
            switch (type)
            {
                case "Druid": return new Druid(name);
                case "Paladin": return new Paladin(name);
                case "Rogue": return new Rogue(name);
                case "Warrior": return new Warrior(name);
                default: throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
