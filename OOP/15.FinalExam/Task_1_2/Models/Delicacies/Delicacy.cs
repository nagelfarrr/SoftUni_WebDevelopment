namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Utilities.Messages;

    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public Delicacy(string delicacyName,double price)
        {
            this.Name = delicacyName;
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
        public double Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:F2} lv";
        }
    }
}