using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using StockTicker.Application.Abstractions.Clock;
using StockTicker.Application.Exceptions;
using StockTicker.Application.Repostitories;
using StockTicker.Application.StockPrices.CreateStockPrice;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.UnitTests.StockPrices
{
    public class CreateStockPriceTests
    {
        private static readonly DateTime UtcNow = DateTime.UtcNow;
        private static readonly CreateStockPriceCommand Command = new(
            "AAPL",
            150.25m,
            UtcNow);

        private CreateStockPriceCommandHandler _handler;
        private readonly IStockPriceRepository _stockPriceRepositoryMock;
        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly IDateTimeProvider _dateTimeProviderMock;

        public CreateStockPriceTests()
        {
            _stockPriceRepositoryMock = Substitute.For<IStockPriceRepository>();
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
            _dateTimeProviderMock.UtcNow.Returns(UtcNow);
        }

        [Fact]
        public async Task Handle_ShouldCreateStockPrice()
        {
            // Arrange
            _handler = new CreateStockPriceCommandHandler(
                _stockPriceRepositoryMock,
                _unitOfWorkMock);

            // Act
            var result = await _handler.Handle(Command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _stockPriceRepositoryMock.Received(1).Add(Arg.Is<StockPrice>(sp =>
                sp.Ticker.Value == Command.Ticker &&
                sp.Price.Value == Command.Price &&
                sp.Timestamp == Command.Timestamp));
            await _unitOfWorkMock.Received(1).SaveChangesAsync(CancellationToken.None);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenUnitOfWorkThrows()
        {
            // Arrange
            _handler = new CreateStockPriceCommandHandler(
                _stockPriceRepositoryMock,
                _unitOfWorkMock);
                _unitOfWorkMock.SaveChangesAsync(Arg.Any<CancellationToken>())
                .ThrowsAsync(new ConcurrencyException("Concurrency", new Exception()));

            // Act
            var result = await _handler.Handle(Command, CancellationToken.None);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(StockPriceErrors.Concurrency);
        }
    }
}
