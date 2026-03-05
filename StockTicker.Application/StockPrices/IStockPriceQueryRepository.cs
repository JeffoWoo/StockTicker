using StockTicker.Application.StockPrices.GetStockPrice;

namespace StockTicker.Application.StockPrices
{
    public interface IStockPriceQueryRepository
    {
        Task<StockPriceResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
