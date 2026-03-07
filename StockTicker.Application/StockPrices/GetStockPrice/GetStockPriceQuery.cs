using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.StockPrices.GetStockPrice
{
    public sealed record GetStockPriceQuery(Guid StockPriceId) : IQuery<StockPrice>
    {
    }
}
