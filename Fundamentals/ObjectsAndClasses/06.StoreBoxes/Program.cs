using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                string[] tokens = input.Split(' ');
                Item item = new Item(tokens[1], float.Parse(tokens[tokens.Length - 1]));
                items.Add(item);

                Box box = new Box(tokens[0], item, int.Parse(tokens[2]));
                boxes.Add(box);

            }

            List<Box> orderedBoxes = boxes.OrderByDescending(box => box.PriceForABox).ToList();

            foreach (var box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} – ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }

    public class Item
    {
        public Item(string name, float price)
        {
            this.Name = name;
            this.Price = price;
            }

        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.ItemQuantity = itemQuantity;
            
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }

        public float PriceForABox
        {
            get
            {
                return ItemQuantity * Item.Price;
            }
        }
    }
}
