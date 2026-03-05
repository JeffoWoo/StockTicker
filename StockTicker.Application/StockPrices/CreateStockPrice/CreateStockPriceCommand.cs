using StockTicker.Application.Abstractions.Messaging;

namespace StockTicker.Application.StockPrices.CreateStockPrice
{
    public sealed record CreateStockPriceCommand(
        string Ticker,
        decimal Price,
        DateTime Timestamp) : ICommand<Guid>;
}
