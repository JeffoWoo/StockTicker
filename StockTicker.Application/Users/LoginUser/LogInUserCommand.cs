using StockTicker.Application.Abstractions.Messaging;

namespace StockTicker.Application.Users.LoginUser
{
    public sealed record LogInUserCommand(string Email, string Password)
        : ICommand<AccessTokenResponse>;
}
