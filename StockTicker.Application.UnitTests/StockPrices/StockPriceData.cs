using StockTicker.Application.StockPrices.GetStockPrice;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class StockPriceData
    {
        public static string Ticker = "AAPL";
        public static decimal Price = 123.45m;
        public static DateTime Timestamp = DateTime.UtcNow;

        public static StockPriceResponse Create()
        {
            return new StockPriceResponse
            {
                Id = Guid.NewGuid(),
                Ticker = Ticker,
                Price = Price,
                Timestamp = Timestamp
            };
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
