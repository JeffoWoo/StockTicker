using StockTicker.Domain.StockPrices;

namespace StockTicker.Domain.UnitTests.StockPrices
{
    public class StockPriceData
    {
        public static Guid StockPriceId = Guid.NewGuid();
        public static string Ticker = "AAPL";
        public static decimal Price = 123.45m;
        public static DateTime Timestamp = DateTime.UtcNow;

        public static StockPrice Create()
        {
            return StockPrice.Create(
                new Ticker(Ticker), 
                new Price(Price), 
                Timestamp).Value;
        }

        public static StockPrice Create(DateTime timeStamp)
        {
            return StockPrice.Create(
                new Ticker(Ticker),
                new Price(Price),
                timeStamp).Value;
        }
    }
}
