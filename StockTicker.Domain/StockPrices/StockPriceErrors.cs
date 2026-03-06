using StockTicker.Domain.Abstractions;

namespace StockTicker.Domain.StockPrices
{
    public static class StockPriceErrors
    {
        public static Error Concurrency = new(
            "StockPrice.Concurrency",
            "A concurrency error occurred while processing the stock price. Please try again.");

        public static Error NotFound = new(
            "StockPrice.NotFound",
            "The specified stock price was not found.");
    }
}
