using StockTicker.Domain.Abstractions;

namespace StockTicker.Domain.StockPrices.Events
{
    public sealed record StockPriceCreatedDomainEvent(
        Guid StockPriceId, 
        Ticker Ticker, 
        Price Price, 
        DateTime CreatedAtUtc) : IDomainEvent
    {
    }
}
