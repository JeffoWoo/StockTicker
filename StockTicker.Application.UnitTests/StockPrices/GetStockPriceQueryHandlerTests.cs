using NSubstitute;
using StockTicker.Application.StockPrices;
using StockTicker.Application.StockPrices.GetStockPrice;

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
            var expectedResponse = new StockPriceResponse
            {
                Id = stockPriceId,
                Symbol = "AAPL",
                Price = 150.25m,
                CreatedAtUtc = DateTime.UtcNow
            };

            _repositoryMock
                .GetByIdAsync(stockPriceId, Arg.Any<CancellationToken>())
                .Returns(expectedResponse);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResponse.Id, result.Value.Id);
            Assert.Equal(expectedResponse.Symbol, result.Value.Symbol);
            Assert.Equal(expectedResponse.Price, result.Value.Price);
            Assert.Equal(expectedResponse.CreatedAtUtc, result.Value.CreatedAtUtc);
        }
    }
}