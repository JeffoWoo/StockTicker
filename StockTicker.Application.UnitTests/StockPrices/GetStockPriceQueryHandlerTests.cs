using NSubstitute;
using StockTicker.Application.StockPrices;
using StockTicker.Application.StockPrices.GetStockPrice;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class GetStockPriceQueryHandlerTests
    {
        private readonly GetStockPriceQueryHandler _handler;
        private readonly IStockPriceQueryRepository _repositoryMock;

        public GetStockPriceQueryHandlerTests()
        {
            _repositoryMock = Substitute.For<IStockPriceQueryRepository>();
            _handler = new GetStockPriceQueryHandler(_repositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnStockPrice_WhenFound()
        {
            var stockPriceId = Guid.NewGuid();
            var query = new GetStockPriceQuery(stockPriceId);
            var expectedStockPrice = StockPriceData.Create();

            _repositoryMock
                .GetByIdAsync(stockPriceId, Arg.Any<CancellationToken>())
                .Returns(expectedStockPrice);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(expectedStockPrice.Id, result.Value.Id);
            Assert.Equal(expectedStockPrice.Ticker, result.Value.Ticker);
            Assert.Equal(expectedStockPrice.Price, result.Value.Price);
            Assert.Equal(expectedStockPrice.Timestamp, result.Value.Timestamp);
        }
    }
}