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

        public static StockPrice Create(string ticker, decimal price, DateTime timestamp)
        {
            var stockPrice = new StockPrice(ticker, price, timestamp);

            stockPrice.RaiseDomainEvent(new StockPriceCreatedDOmainEvent);

            return stockPrice;
        }
    }
}
