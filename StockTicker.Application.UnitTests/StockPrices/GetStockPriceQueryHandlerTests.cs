using FluentAssertions;
using NSubstitute;
using StockTicker.Application.Repostitories;
using StockTicker.Application.StockPrices.GetStockPrice;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class GetStockPriceQueryHandlerTests
    {
        private readonly GetStockPriceQueryHandler _handler;
        private readonly IStockPriceRepository _repositoryMock;

        public GetStockPriceQueryHandlerTests()
        {
            _repositoryMock = Substitute.For<IStockPriceRepository>();
            _handler = new GetStockPriceQueryHandler(_repositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnStockPrice_WhenFound()
        {
            // Arrange
            var stockPriceId = Guid.NewGuid();
            var query = new GetStockPriceQuery(stockPriceId);
            var expectedStockPrice = StockPriceData.Create();

            _repositoryMock
                .GetByIdAsync(stockPriceId, Arg.Any<CancellationToken>())
                .Returns(expectedStockPrice);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);


            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Id.Should().Be(expectedStockPrice.Id);
            result.Value.Ticker.Should().Be(expectedStockPrice.Ticker);
            result.Value.Price.Should().Be(expectedStockPrice.Price);
            result.Value.Timestamp.Should().Be(expectedStockPrice   .Timestamp);
        }
    }
}