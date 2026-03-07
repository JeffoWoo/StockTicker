namespace StockTicker.Domain.StockPrices
{
    public interface IStockPriceQueryRepository
    {
        Task<StockPrice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
