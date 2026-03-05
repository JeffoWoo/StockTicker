namespace StockTicker.Domain.StockPrices
{
    public interface IStockPriceRepository
    {
        void Add(StockPrice stockPrice);
    }
}
