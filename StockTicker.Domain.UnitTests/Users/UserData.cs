using StockTicker.Domain.Users;

namespace StockTicker.Domain.UnitTests.Users
{
    public class UserData
    {
        public static readonly FirstName FirstName = new FirstName("First");
        public static readonly LastName LastName = new LastName("Last");
        public static readonly Email Email = new Email("test@test.com");
    }
}
