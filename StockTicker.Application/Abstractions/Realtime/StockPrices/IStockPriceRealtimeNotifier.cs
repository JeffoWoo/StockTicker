namespace StockTicker.Application.Abstractions.Realtime.StockPrices
{
    public interface IStockPriceRealtimeNotifier
    {
        Task StockPriceCreatedAsync(StockPriceCreatedNotification response, CancellationToken cancellationToken = default);
    }
}
