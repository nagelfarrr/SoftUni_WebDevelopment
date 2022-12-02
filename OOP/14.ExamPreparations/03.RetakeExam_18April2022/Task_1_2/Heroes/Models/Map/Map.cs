namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using global::Heroes.Models.Contracts;
    

    public class Map :IMap
    {
        

        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(h => h.GetType().Name == "Knight").ToList();
            List<IHero> barbarians = players.Where(h => h.GetType().Name == "Barbarian").ToList();

            
            while (knights.Any(k=>k.IsAlive) && barbarians.Any(b=>b.IsAlive))
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        if (knight.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        if (barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
                
            }

            if (knights.Any(k => k.IsAlive))
            {
                return $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle.";
            }
            else
               return $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle.";
        }
    }
}
