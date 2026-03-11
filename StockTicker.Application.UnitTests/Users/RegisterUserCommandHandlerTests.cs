using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using StockTicker.Application.Abstractions.Authentication;
using StockTicker.Application.Exceptions;
using StockTicker.Application.Repostitories;
using StockTicker.Application.Users.RegisterUser;
using StockTicker.Domain.Abstractions;
using StockTicker.Domain.Users;
using static Dapper.SqlMapper;

namespace StockTicker.Application.UnitTests.Users
{
    public class RegisterUserCommandHandlerTests
    {
        private static readonly RegisterUserCommand Command = new(
            UserData.Email.Value,
            UserData.FirstName.Value,
            UserData.LastName.Value,
            UserData.Password);

        private readonly RegisterUserCommandHandler _handler;
        private readonly IUserRepository _userRepositoryMock;
        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserCommandHandlerTests()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _authenticationService = Substitute.For<IAuthenticationService>();

            _handler = new RegisterUserCommandHandler(
                _authenticationService,
                _userRepositoryMock,
                _unitOfWorkMock);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenBookingIsReserved()
        {
            // Arrange
            var identityId = Guid.NewGuid().ToString();
            _authenticationService
                .RegisterAsync(
                    Arg.Is<User>(u => u.Email.Value == UserData.Email.Value),
                    UserData.Password,
                    Arg.Any<CancellationToken>())
                .Returns(identityId);

            // Act
            var result = await _handler.Handle(Command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_CallRepository_WhenBookingIsReserved()
        {
            // Arrange
            var identityId = Guid.NewGuid().ToString();
            _authenticationService
                .RegisterAsync(
                    Arg.Is<User>(u => u.Email.Value == UserData.Email.Value),
                    UserData.Password,
                    Arg.Any<CancellationToken>())
                .Returns(identityId);

            // Act
            var result = await _handler.Handle(Command, default);

            // Assert
            _userRepositoryMock.Received(1).Add(Arg.Is<User>(b => b.Id == result.Value));
        }
    }
}
