using FluentAssertions;
using StockTicker.Domain.UnitTests.Infrastructure;
using StockTicker.Domain.Users;
using StockTicker.Domain.Users.Events;

namespace StockTicker.Domain.UnitTests.Users
{
    public class UserTests : BaseTest
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            // Arrange

            // Act
            var user = User.Register(UserData.FirstName, UserData.LastName, UserData.Email);

            // Assert
            user.FirstName.Should().Be(UserData.FirstName);
            user.LastName.Should().Be(UserData.LastName);
            user.Email.Should().Be(UserData.Email);
        }

        [Fact]
        public void Create_Should_RaiseUserCreatedDomainEvent()
        {
            // Arrange

            // Act
            var user = User.Register(UserData.FirstName, UserData.LastName, UserData.Email);

            // Assert
            var domainEvent = AssertDomainEventWasPublished<UserRegisteredDomainEvent>(user);
            domainEvent.Should().NotBeNull();
            domainEvent.UserId.Should().Be(user.Id);
        }

        [Fact]
        public void Create_Should_AddRegisteredRoleToUser()
        {
            // Arrange

            // Act
            var user = User.Register(UserData.FirstName, UserData.LastName, UserData.Email);

            // Assert
            user.Roles.Should().Contain(Role.Registered);
        }
    }
}
