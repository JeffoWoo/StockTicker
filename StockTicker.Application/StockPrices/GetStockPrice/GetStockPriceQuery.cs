using StockTicker.Application.Abstractions.Messaging;

namespace StockTicker.Application.StockPrices.GetStockPrice
{
    public sealed record GetStockPriceQuery(Guid StockPriceId) : IQuery<StockPriceResponse>
    {
    }
}
