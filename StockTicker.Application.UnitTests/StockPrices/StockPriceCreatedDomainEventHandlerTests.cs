using NSubstitute;
using StockTicker.Application.Abstractions.Realtime.StockPrices;
using StockTicker.Application.StockPrices.CreateStockPrice;
using StockTicker.Domain.StockPrices.Events;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class StockPriceCreatedDomainEventHandlerTests
    {
        private readonly IStockPriceRealtimeNotifier _stockPriceRealtimeNotifierMock;
        private readonly StockPriceCreatedDomainEventHandler _handler;


        public StockPriceCreatedDomainEventHandlerTests()
        {
            _stockPriceRealtimeNotifierMock = Substitute.For<IStockPriceRealtimeNotifier>();
            _handler = new StockPriceCreatedDomainEventHandler(_stockPriceRealtimeNotifierMock);
        }

        [Fact]
        public async Task Handle_ShouldNotifyRealtime_WhenStockPriceCreated()
        {
            // Arrange
            var domainEvent = new StockPriceCreatedDomainEvent(
                Guid.NewGuid(),
                "AAPL",
                150.25m,
                DateTime.UtcNow);

            // Act
            await _handler.Handle(domainEvent, CancellationToken.None);

            // Assert
            await _stockPriceRealtimeNotifierMock.Received(1).StockPriceCreatedAsync(
                Arg.Is<StockPriceCreatedNotification>(n =>
                    n.StockPriceId == domainEvent.StockPriceId &&
                    n.Symbol == domainEvent.Symbol &&
                    n.Price == domainEvent.Price &&
                    n.CreatedAtUtc == domainEvent.CreatedAtUtc),
                CancellationToken.None);
        }
    }
}
