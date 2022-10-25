using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;


        public Investor(string fullname, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();

            this.FullName = fullname;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }

        public int Count
        {
            get
            {
                return this.Portfolio.Count;
            }
        }

        public void BuyStock(Stock stock)
        {
            if (!this.Portfolio.Contains(stock))
            {
                if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
                {
                    this.Portfolio.Add(stock);
                    this.MoneyToInvest -= stock.PricePerShare;
                }
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = this.Portfolio.Find(p => p.CompanyName == companyName);

            if (stock == null)
                return $"{companyName} does not exist.";

            if (sellPrice < stock.PricePerShare)
                return $"Cannot sell {companyName}.";

            this.Portfolio.Remove(stock);
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";

        }

        public Stock FindStock(string companyName)
        {
            return this.Portfolio.Find(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }


        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
