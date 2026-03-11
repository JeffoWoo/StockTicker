using FluentValidation;

namespace StockTicker.Application.Users.LoginUser
{
    internal sealed class LogInUserCommandValidator : AbstractValidator<LogInUserCommand>
    {
        public LogInUserCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty().EmailAddress();

            RuleFor(c => c.Password).NotEmpty().MinimumLength(5);
        }
    }
}
