using StockTicker.Domain.Abstractions;

namespace StockTicker.Domain.StockPrices.Events
{
    public sealed record StockPriceCreatedDomainEvent(Guid StockPriceId) : IDomainEvent
    {
    }
}
