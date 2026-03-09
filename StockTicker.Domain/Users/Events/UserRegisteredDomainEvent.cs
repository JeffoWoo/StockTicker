using StockTicker.Domain.Abstractions;

namespace StockTicker.Domain.Users.Events
{
    public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;
}
