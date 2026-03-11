using StockTicker.Application.Abstractions.Authentication;
using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.Users;

namespace StockTicker.Application.Users.LoginUser
{
    internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
    {
        private readonly IJwtService _jwtService;

        public LogInUserCommandHandler(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task<Result<AccessTokenResponse>> Handle(
            LogInUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _jwtService.GetAccessTokenAsync(
                request.Email,
                request.Password,
                cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
            }

            return new AccessTokenResponse(result.Value);
        }
    }
}