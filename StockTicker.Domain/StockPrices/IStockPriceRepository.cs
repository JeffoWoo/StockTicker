namespace StockTicker.Domain.StockPrices
{
    public interface IStockPriceRepository
    {
        void Add(StockPrice stockPrice);

        Task<StockPrice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
