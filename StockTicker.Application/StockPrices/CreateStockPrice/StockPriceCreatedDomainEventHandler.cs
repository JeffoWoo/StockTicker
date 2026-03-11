using MediatR;
using StockTicker.Application.Abstractions.Realtime.StockPrices;
using StockTicker.Domain.StockPrices.Events;

namespace StockTicker.Application.StockPrices.CreateStockPrice
{
    internal sealed class StockPriceCreatedDomainEventHandler : INotificationHandler<StockPriceCreatedDomainEvent>
    {
        private readonly IStockPriceRealtimeNotifier _stockPriceRealtimeNotifier;

        public StockPriceCreatedDomainEventHandler(IStockPriceRealtimeNotifier stockPriceRealtimeNotifier)
        {
            _stockPriceRealtimeNotifier = stockPriceRealtimeNotifier;
        }

        public async Task Handle(StockPriceCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var payload = new StockPriceCreatedNotification(
                notification.StockPriceId,
                notification.Ticker.Value,
                notification.Price.Value,
                notification.CreatedAtUtc);

            await _stockPriceRealtimeNotifier.StockPriceCreatedAsync(payload, cancellationToken);
        }
    }
}
