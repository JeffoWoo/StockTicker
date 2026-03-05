using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices.Events;

namespace StockTicker.Domain.StockPrices
{
    public sealed class StockPrice : Entity
    {
        private StockPrice(string ticker, decimal price, DateTime timestamp)
        {
            Ticker = ticker;
            Price = price;
            Timestamp = timestamp;
        }

        private StockPrice()
        { 
        }

        public string Ticker { get; private set; }
        public decimal Price { get; private set; }
        public DateTime Timestamp { get; private set; }

        public static Result<StockPrice> Create(string ticker, decimal price, DateTime timestamp)
        {
            var stockPrice = new StockPrice(ticker, price, timestamp);

            stockPrice.RaiseDomainEvent(new StockPriceCreatedDomainEvent(stockPrice.Id));

            return stockPrice;
        }
    }
}
