using StockTicker.Application.StockPrices.GetStockPrice;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.Repostitories
{
    public interface IStockPriceRepository
    {
        void Add(StockPrice stockPrice);

        Task<StockPriceResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
