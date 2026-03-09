using StockTicker.Domain.Users;

namespace StockTicker.Application.UnitTests.Users
{
    internal static class UserData
    {
        public static User Register() => User.Register(
            FirstName,
            LastName,
            Email);

        public static readonly FirstName FirstName = new FirstName("First");
        public static readonly LastName LastName = new LastName("Last");
        public static readonly Email Email = new Email("test@test.com");
        public static readonly string Password = "test@test.com";
    }
}
