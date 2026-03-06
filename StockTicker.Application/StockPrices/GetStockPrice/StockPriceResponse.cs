namespace StockTicker.Application.StockPrices.GetStockPrice
{
    public sealed class StockPriceResponse
    {
        public Guid Id { get; init; }
        public string Symbol { get; init; }
        public decimal Price { get; init; }
        public DateTime CreatedAtUtc { get; init; }
    }
}
