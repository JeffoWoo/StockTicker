using FluentAssertions;
using StockTicker.Domain.StockPrices.Events;
using StockTicker.Domain.UnitTests.Infrastructure;

namespace StockTicker.Domain.UnitTests.StockPrices
{
    public class StockPriceTests : BaseTest
    {
        [Fact]
        public void Create_Should_RaiseBookingCreatedDomainEvent() 
        {
            // Act
            var stockPrice = StockPriceData.Create();

            // Assert
            var domainEvent = AssertDomainEventWasPublished<StockPriceCreatedDomainEvent>(stockPrice);
            domainEvent.Should().NotBeNull();
            domainEvent.StockPriceId.Should().Be(stockPrice.Id);
            domainEvent.Ticker.Should().Be(stockPrice.Ticker);
            domainEvent.Price.Should().Be(stockPrice.Price);
            domainEvent.CreatedAtUtc.Should().Be(stockPrice.Timestamp);
        }
    }
}
