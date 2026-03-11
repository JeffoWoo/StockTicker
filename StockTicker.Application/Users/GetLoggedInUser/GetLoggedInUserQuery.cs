using StockTicker.Application.Abstractions.Messaging;

namespace StockTicker.Application.Users.GetLoggedInUser
{
    public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
}
