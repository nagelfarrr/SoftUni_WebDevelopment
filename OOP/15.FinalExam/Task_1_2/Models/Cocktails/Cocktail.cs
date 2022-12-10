namespace ChristmasPastryShop.Models.Cocktails
{
    using System;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Utilities.Messages;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }
        public string Size { get; private set; } //may need work

        public double Price
        {
            get => this.price;
            private set
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                else if (this.Size == "Middle")
                {
                    this.price = (2.00 / 3.00) * value;
                }
                else if (this.Size == "Small")
                {
                    this.price = (1.00 / 3.00) * value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:F2} lv";
        }
    }
}
