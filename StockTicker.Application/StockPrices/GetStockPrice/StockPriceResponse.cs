namespace StockTicker.Application.StockPrices.GetStockPrice
{
    public sealed class StockPriceResponse
    {
        public Guid Id { get; init; }
        public string Ticker { get; init; }
        public decimal Price { get; init; }
        public DateTime Timestamp { get; init; }
    }
}
