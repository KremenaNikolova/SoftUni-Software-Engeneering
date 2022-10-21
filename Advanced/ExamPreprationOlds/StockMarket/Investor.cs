using System.Collections.Generic;
using System.Linq;
using System;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();

            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        //FullName: string
        //EmailAddress: string
        //MoneyToInvest: decimal
        //BrokerName: string

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get { return Portfolio.Count; } }


        public void BuyStock(Stock stock)
        {
            //add a single stock of the given company if the stock’s market capitalization is bigger than $10000 and the investor has enough money. 
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                //Then reduce the MoneyToInvest by the price of the stock.
                MoneyToInvest -= stock.PricePerShare;
            }
            //If a stock cannot be bought the method should not do anything.
        }
        public string SellStock(string companyName, decimal sellPrice) // sell a Stock from the portfolio with the given company name for the given price: 
        {
            //If the company does not exist return: "{companyName} does not exist."
            
            if (!this.Portfolio.Any(x=>x.CompanyName==companyName))
            {
                return $"{companyName} does not exist.";
            }
            //If the selling price is smaller than the price per share return: "Cannot sell {companyName}."
            Stock stock = this.Portfolio.First(x => x.CompanyName == companyName);
            if (stock.PricePerShare>sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            //Upon successful sell, you should remove the company from the portfolio, increase Money to Invest with the selling price, and return: "{companyName} was sold."
            this.Portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName) // returns a Stock with the given company name.If it doesn't exist, return null
        {
            return Portfolio.Find(x => x.CompanyName == companyName);
            
        }
        public Stock FindBiggestCompany() // returns the Stock with the biggest market capitalization.If there are no stocks in the portfolio, the method should return null. 
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
            
        public string InvestorInformation() // returns information about the Investor and his portfolio in the following format:
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, Portfolio)}";
        }
    }
}
