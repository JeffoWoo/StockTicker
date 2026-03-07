using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class StockPriceData
    {
        public static string Ticker = "AAPL";
        public static decimal Price = 123.45m;
        public static DateTime Timestamp = DateTime.UtcNow;

        public static StockPrice Create()
        {
            return StockPrice.Create(StockPriceData.Ticker, StockPriceData.Price, StockPriceData.Timestamp).Value;
        }

        public static StockPrice Create(DateTime timeStamp)
        {
            return StockPrice.Create(StockPriceData.Ticker, StockPriceData.Price, timeStamp).Value;
        }
    }
}
