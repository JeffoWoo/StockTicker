using StockTicker.Application.Users.GetLoggedInUser;
using StockTicker.Domain.Users;

namespace StockTicker.Application.Repostitories
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
