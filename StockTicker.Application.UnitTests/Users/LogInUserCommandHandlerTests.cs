using FluentAssertions;
using NSubstitute;
using StockTicker.Application.Abstractions.Authentication;
using StockTicker.Application.Users.LoginUser;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.Users;

namespace StockTicker.Application.UnitTests.Users
{
    public class LogInUserCommandHandlerTests
    {
        private readonly IJwtService _jwtService;
        private readonly LogInUserCommandHandler _handler;

        public LogInUserCommandHandlerTests()
        {
            _jwtService = Substitute.For<IJwtService>();
            _handler = new LogInUserCommandHandler(_jwtService);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_When_JwtService_Returns_Failure()
        {
            // Arrange
            var command = new LogInUserCommand("user@example.com", "password123");
            _jwtService.GetAccessTokenAsync(command.Email, command.Password, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(Result.Failure<string>(UserErrors.InvalidCredentials)));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(UserErrors.InvalidCredentials);
        }

        [Fact]
        public async Task Handle_Should_ReturnAccessToken_When_JwtService_Returns_Success()
        {
            // Arrange
            var token = "access-token";
            var command = new LogInUserCommand("user@example.com", "password123");
            _jwtService.GetAccessTokenAsync(command.Email, command.Password, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(Result.Success(token)));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.AccessToken.Should().Be(token);
        }
    }
}
