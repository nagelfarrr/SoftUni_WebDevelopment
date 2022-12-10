namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Text;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;

    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;

        public Booth(int boothId, int capacity)
        {
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();

            this.BoothId = boothId;
            this.Capacity = capacity;
        }

        public int BoothId
        {
            get => this.boothId;
            private set
            {
                this.boothId = value;
            }
        }
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;
        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }
        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;

            this.CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:F2} lv");
            sb.AppendLine("-Cocktail menu:");

            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
