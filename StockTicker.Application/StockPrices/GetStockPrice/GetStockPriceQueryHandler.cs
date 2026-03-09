using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.StockPrices.GetStockPrice
{
    internal sealed class GetStockPriceQueryHandler : IQueryHandler<GetStockPriceQuery, StockPrice>
    {
        private readonly IStockPriceRepository _repository;

        public GetStockPriceQueryHandler(IStockPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<StockPrice>> Handle(GetStockPriceQuery request, CancellationToken cancellationToken)
        {
            var stockPrice = await _repository.GetByIdAsync(request.StockPriceId, cancellationToken);

            if (stockPrice is null)
            {
                return Result.Failure<StockPrice>(StockPriceErrors.NotFound);
            }

            return stockPrice;
        }
    }
}
