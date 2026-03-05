using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.StockPrices.GetStockPrice
{
    internal sealed class GetStockPriceQueryHandler : IQueryHandler<GetStockPriceQuery, StockPriceResponse>
    {
        private readonly IStockPriceQueryRepository _repository;

        public GetStockPriceQueryHandler(IStockPriceQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<StockPriceResponse>> Handle(GetStockPriceQuery request, CancellationToken cancellationToken)
        {
            var stockPrice = await _repository.GetByIdAsync(request.StockPriceId, cancellationToken);

            if (stockPrice is null)
            {
                return Result.Failure<StockPriceResponse>(StockPriceErrors.NotFound);
            }

            return stockPrice;
        }
    }
}
