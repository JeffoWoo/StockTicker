using FluentAssertions;
using StockTicker.Application.Users.LoginUser;

namespace StockTicker.Application.UnitTests.Users
{
    public class LogInUserCommandValidatorTests
    {
        private readonly LogInUserCommandValidator _validator = new();

        private static readonly LogInUserCommand ValidCommand = new(
            "user@example.com",
            "password123"
        );

        [Fact]
        public void Validate_Should_Pass_For_Valid_Command()
        {
            // Act
            var result = _validator.Validate(ValidCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_Should_Fail_When_Email_Is_Empty()
        {
            // Arrange
            var command = new LogInUserCommand(string.Empty, ValidCommand.Password);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Email");
        }

        [Fact]
        public void Validate_Should_Fail_When_Email_Is_Invalid()
        {
            // Arrange
            var command = new LogInUserCommand("not-an-email", ValidCommand.Password);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Email");
        }

        [Fact]
        public void Validate_Should_Fail_When_Password_Is_Empty()
        {
            // Arrange
            var command = new LogInUserCommand(ValidCommand.Email, string.Empty);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Password");
        }

        [Fact]
        public void Validate_Should_Fail_When_Password_Is_Too_Short()
        {

            // Arrange
            var command = new LogInUserCommand(ValidCommand.Email, "1234");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Password");
        }
    }
}
