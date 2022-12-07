namespace Gym.Models.Equipment
{
    using Gym.Models.Equipment.Contracts;

    public abstract class Equipment :IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight,decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                this.weight = value;
            }

        }
        public decimal Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }

        }
    }
}
