namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private List<string> items;
        public Backpack()
        {
            items = new List<string>();
        }

        public ICollection<string> Items => items;

    }
}
