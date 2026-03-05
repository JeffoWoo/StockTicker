using MediatR;
using StockTicker.Domain.Abstractions;

namespace StockTicker.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
