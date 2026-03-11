using FluentAssertions;
using StockTicker.Application.Users.RegisterUser;

namespace StockTicker.Application.UnitTests.Users
{
    public class RegisterUserCommandValidatorTests
    {
        private readonly RegisterUserCommandValidator _validator = new();

        private static readonly RegisterUserCommand ValidCommand = new(
            "user@example.com",
            "John",
            "Doe",
            "secret"
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
        public void Validate_Should_Fail_When_FirstName_Is_Empty()
        {
            // Arrange
            var command = new RegisterUserCommand(ValidCommand.Email, string.Empty, ValidCommand.LastName, ValidCommand.Password);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "FirstName");
        }

        [Fact]
        public void Validate_Should_Fail_When_LastName_Is_Empty()
        {
            // Arrange
            var command = new RegisterUserCommand(ValidCommand.Email, ValidCommand.FirstName, string.Empty, ValidCommand.Password);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "LastName");
        }

        [Fact]
        public void Validate_Should_Fail_When_Email_Is_Empty()
        {
            // Arrange
            var command = new RegisterUserCommand(string.Empty, ValidCommand.FirstName, ValidCommand.LastName, ValidCommand.Password);

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
            var command = new RegisterUserCommand("not-an-email", ValidCommand.FirstName, ValidCommand.LastName, ValidCommand.Password);

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
            var command = new RegisterUserCommand(ValidCommand.Email, ValidCommand.FirstName, ValidCommand.LastName, string.Empty);

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
            var command = new RegisterUserCommand(ValidCommand.Email, ValidCommand.FirstName, ValidCommand.LastName, "1234");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Password");
        }
    }
}
