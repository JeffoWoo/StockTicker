namespace StockTicker.Domain.StockPrices
{
    public interface IStockPriceWriteRepository
    {
        void Add(StockPrice stockPrice);
    }
}
