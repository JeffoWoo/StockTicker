using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Application.Exceptions;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.StockPrices.CreateStockPrice
{
    internal sealed class CreateStockPriceCommandHandler : ICommandHandler<CreateStockPriceCommand, Guid>
    {
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStockPriceCommandHandler(
            IStockPriceRepository stockPriceRepository,
            IUnitOfWork unitOfWork)
        {
            _stockPriceRepository = stockPriceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateStockPriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stockPrice = StockPrice.Create(
                    request.Ticker,
                    request.Price,
                    request.Timestamp);

                _stockPriceRepository.Add(stockPrice.Value);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return stockPrice.Value.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(StockPriceErrors.Concurrency);
            }
        }
    }
}