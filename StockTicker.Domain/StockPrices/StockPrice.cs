using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices.Events;

namespace StockTicker.Domain.StockPrices
{
    public sealed class StockPrice : Entity
    {
        private StockPrice(Guid id, Ticker ticker, Price price, DateTime timestamp)
            :base(id)
        {
            Ticker = ticker;
            Price = price;
            Timestamp = timestamp;
        }

        private StockPrice()
        { 
        }

        public Ticker Ticker { get; private set; }
        public Price Price { get; private set; }
        public DateTime Timestamp { get; private set; }

        public static Result<StockPrice> Create(Ticker ticker, Price price, DateTime timestamp)
        {
            var stockPrice = new StockPrice(Guid.NewGuid(), ticker, price, timestamp);

            stockPrice.RaiseDomainEvent(new StockPriceCreatedDomainEvent(
                stockPrice.Id,
                ticker, 
                price, 
                timestamp));

            return stockPrice;
        }
    }
}
