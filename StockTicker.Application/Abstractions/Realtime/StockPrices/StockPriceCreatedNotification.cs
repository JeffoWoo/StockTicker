namespace StockTicker.Application.Abstractions.Realtime.StockPrices
{
    public sealed record StockPriceCreatedNotification(Guid StockPriceId, string Symbol, decimal Price, DateTime CreatedAtUtc);
}
